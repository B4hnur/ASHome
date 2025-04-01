using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using Font = iTextSharp.text.Font;
using ASHome.Models;

namespace ASHome.Utils
{
    /// <summary>
    /// Helper class for exporting data
    /// </summary>
    public static class ExportHelper
    {
        /// <summary>
        /// Export DataGridView to Excel
        /// </summary>
        /// <param name="dgv">DataGridView to export</param>
        /// <param name="title">Report title</param>
        /// <param name="sheetName">Excel sheet name</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool ExportToExcel(DataGridView dgv, string title, string sheetName)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.Title = "Excel faylı kimi saxla";
                    sfd.FileName = $"{title}_{DateTime.Now.ToString("yyyyMMdd")}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Set EPPlus license context
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (ExcelPackage package = new ExcelPackage())
                        {
                            // Add a new worksheet to the package
                            var worksheet = package.Workbook.Worksheets.Add(sheetName);

                            // Add title
                            worksheet.Cells["A1"].Value = title;
                            worksheet.Cells["A1:H1"].Merge = true;
                            worksheet.Cells["A1"].Style.Font.Bold = true;
                            worksheet.Cells["A1"].Style.Font.Size = 14;
                            worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            // Export column headers
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible)
                                {
                                    worksheet.Cells[3, i + 1].Value = dgv.Columns[i].HeaderText;
                                    worksheet.Cells[3, i + 1].Style.Font.Bold = true;
                                    worksheet.Cells[3, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                                    worksheet.Cells[3, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }
                            }

                            // Export data
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    if (dgv.Columns[j].Visible)
                                    {
                                        if (dgv.Rows[i].Cells[j].Value != null)
                                        {
                                            worksheet.Cells[i + 4, j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();
                                        }
                                        worksheet.Cells[i + 4, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                    }
                                }
                            }

                            // Auto fit columns
                            worksheet.Cells.AutoFitColumns();

                            // Save the Excel file
                            package.SaveAs(new FileInfo(sfd.FileName));
                        }

                        MessageBox.Show("Excel faylı uğurla yaradıldı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel faylı yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Export DataGridView to Excel with automatically generated sheet name
        /// </summary>
        /// <param name="dgv">DataGridView to export</param>
        /// <param name="filename">File name for Excel file</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool ExportToExcel(DataGridView dgv, string filename)
        {
            // Extract title from filename and use it as sheet name
            string title = System.IO.Path.GetFileNameWithoutExtension(filename);
            string sheetName = "Məlumat"; // Default sheet name in Azerbaijani

            return ExportToExcel(dgv, title, sheetName);
        }

        /// <summary>
        /// Export DataGridView to PDF
        /// </summary>
        /// <param name="dgv">DataGridView to export</param>
        /// <param name="title">Report title</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool ExportToPdf(DataGridView dgv, string title)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.Title = "PDF faylı kimi saxla";
                    sfd.FileName = $"{title}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Create document
                        Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                        // Create writer
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));

                        // Open document
                        document.Open();

                        // Add title
                        Font titleFont = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);
                        Paragraph titleParagraph = new Paragraph(title, titleFont);
                        titleParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(titleParagraph);

                        // Add date
                        Font dateFont = new Font(Font.FontFamily.HELVETICA, 8);
                        Paragraph dateParagraph = new Paragraph($"Tarix: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}", dateFont);
                        dateParagraph.Alignment = Element.ALIGN_RIGHT;
                        document.Add(dateParagraph);

                        // Add space
                        document.Add(new Paragraph(" "));

                        // Create table
                        PdfPTable table = new PdfPTable(dgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible));
                        table.WidthPercentage = 100;

                        // Add column headers
                        Font headerFont = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            if (column.Visible)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                                cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.Padding = 5;
                                table.AddCell(cell);
                            }
                        }

                        // Add data
                        Font dataFont = new Font(Font.FontFamily.HELVETICA, 8);
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Visible && cell.OwningColumn.Visible)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", dataFont));
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    pdfCell.Padding = 3;
                                    table.AddCell(pdfCell);
                                }
                            }
                        }

                        // Add table to document
                        document.Add(table);

                        // Close document
                        document.Close();

                        MessageBox.Show("PDF faylı uğurla yaradıldı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF faylı yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Export report data to PDF
        /// </summary>
        /// <param name="reportData">Report data</param>
        /// <param name="title">Report title</param>
        /// <param name="columns">Column headers</param>
        /// <param name="subtitle">Report subtitle</param>
        /// <param name="footerText">Footer text</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool ExportReportToPdf(DataTable reportData, string title, string[] columns, string subtitle = null, string footerText = null)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.Title = "PDF faylı kimi saxla";
                    sfd.FileName = $"{title}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Create document
                        Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                        // Create writer
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sfd.FileName, FileMode.Create));

                        // Open document
                        document.Open();

                        // Add company info
                        Font companyFont = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD);
                        Paragraph companyParagraph = new Paragraph("AS Home", companyFont);
                        companyParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(companyParagraph);

                        // Add title
                        Font titleFont = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);
                        Paragraph titleParagraph = new Paragraph(title, titleFont);
                        titleParagraph.Alignment = Element.ALIGN_CENTER;
                        document.Add(titleParagraph);

                        // Add date
                        Font dateFont = new Font(Font.FontFamily.HELVETICA, 8);
                        Paragraph dateParagraph = new Paragraph($"Tarix: {DateTime.Now.ToString("dd.MM.yyyy HH:mm")}", dateFont);
                        dateParagraph.Alignment = Element.ALIGN_RIGHT;
                        document.Add(dateParagraph);

                        // Add space
                        document.Add(new Paragraph(" "));

                        // Create table
                        PdfPTable table = new PdfPTable(columns.Length);
                        table.WidthPercentage = 100;

                        // Add column headers
                        Font headerFont = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
                        foreach (string column in columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column, headerFont));
                            cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }

                        // Add data
                        Font dataFont = new Font(Font.FontFamily.HELVETICA, 8);
                        foreach (DataRow row in reportData.Rows)
                        {
                            foreach (DataColumn column in reportData.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString(), dataFont));
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.Padding = 3;
                                table.AddCell(cell);
                            }
                        }

                        // Add table to document
                        document.Add(table);

                        // Close document
                        document.Close();

                        MessageBox.Show("PDF faylı uğurla yaradıldı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF faylı yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Export report to PDF with charts
        /// </summary>
        /// <param name="filename">Output filename</param>
        /// <param name="reportTitle">Report title</param>
        /// <param name="summaryData">Summary data dictionary</param>
        /// <param name="chartPaths">Chart image paths dictionary</param>
        /// <param name="performersGrid">Top performers grid</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool ExportReportToPdf(string filename, string reportTitle,
            Dictionary<string, string> summaryData, Dictionary<string, string> chartPaths,
            DataGridView performersGrid)
        {
            try
            {
                // Create document
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);

                // Create writer
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

                // Open document
                document.Open();

                // Add company info
                Font companyFont = new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD);
                Paragraph companyParagraph = new Paragraph("AS Home", companyFont);
                companyParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(companyParagraph);

                // Add title
                Font titleFont = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD);
                Paragraph titleParagraph = new Paragraph("Aylıq Hesabat", titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(titleParagraph);

                // Add report period
                Font periodFont = new Font(Font.FontFamily.HELVETICA, 10);
                Paragraph periodParagraph = new Paragraph(reportTitle, periodFont);
                periodParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(periodParagraph);

                // Add date
                Font dateFont = new Font(Font.FontFamily.HELVETICA, 8);
                Paragraph dateParagraph = new Paragraph($"Yaradılma tarixi: {DateTime.Now:dd.MM.yyyy HH:mm}", dateFont);
                dateParagraph.Alignment = Element.ALIGN_RIGHT;
                document.Add(dateParagraph);

                // Add space
                document.Add(new Paragraph(" "));

                // Add summary section
                Font sectionFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);
                Paragraph summarySection = new Paragraph("Ümumi Məlumatlar", sectionFont);
                document.Add(summarySection);

                // Create summary table
                PdfPTable summaryTable = new PdfPTable(2);
                summaryTable.WidthPercentage = 100;
                summaryTable.SetWidths(new float[] { 1, 1 });

                // Add summary data
                Font dataFont = new Font(Font.FontFamily.HELVETICA, 9);
                Font headerFont = new Font(Font.FontFamily.HELVETICA, 9, Font.BOLD);

                foreach (var item in summaryData)
                {
                    PdfPCell keyCell = new PdfPCell(new Phrase(item.Key, headerFont));
                    keyCell.BorderWidth = 0.5f;
                    keyCell.Padding = 4;
                    summaryTable.AddCell(keyCell);

                    PdfPCell valueCell = new PdfPCell(new Phrase(item.Value, dataFont));
                    valueCell.BorderWidth = 0.5f;
                    valueCell.Padding = 4;
                    summaryTable.AddCell(valueCell);
                }

                document.Add(summaryTable);
                document.Add(new Paragraph(" "));

                // Add charts section
                Paragraph chartsSection = new Paragraph("Qrafiklər", sectionFont);
                document.Add(chartsSection);
                document.Add(new Paragraph(" "));

                // Add charts
                foreach (var chart in chartPaths)
                {
                    if (File.Exists(chart.Value))
                    {
                        // Add chart title
                        Paragraph chartTitle = new Paragraph(chart.Key, headerFont);
                        chartTitle.Alignment = Element.ALIGN_CENTER;
                        document.Add(chartTitle);

                        // Add chart image
                        iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(chart.Value);
                        chartImage.ScaleToFit(500, 250);
                        chartImage.Alignment = Element.ALIGN_CENTER;
                        document.Add(chartImage);
                        document.Add(new Paragraph(" "));
                    }
                }

                // Add top performers section
                if (performersGrid != null && performersGrid.Rows.Count > 0)
                {
                    Paragraph performersSection = new Paragraph("Ən Yaxşı İşçilər", sectionFont);
                    document.Add(performersSection);
                    document.Add(new Paragraph(" "));

                    // Create performers table
                    PdfPTable performersTable = new PdfPTable(performersGrid.Columns.Count);
                    performersTable.WidthPercentage = 100;

                    // Add column headers
                    foreach (DataGridViewColumn column in performersGrid.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                        cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Padding = 4;
                        performersTable.AddCell(cell);
                    }

                    // Add data
                    for (int i = 0; i < performersGrid.Rows.Count; i++)
                    {
                        for (int j = 0; j < performersGrid.Columns.Count; j++)
                        {
                            object cellValue = performersGrid.Rows[i].Cells[j].Value;
                            string cellText = cellValue != null ? cellValue.ToString() : "";

                            PdfPCell cell = new PdfPCell(new Phrase(cellText, dataFont));
                            cell.Padding = 3;
                            performersTable.AddCell(cell);
                        }
                    }

                    document.Add(performersTable);
                }

                // Add footer
                document.Add(new Paragraph(" "));
                Paragraph footer = new Paragraph("© AS Home - Bütün hüquqlar qorunur.", dateFont);
                footer.Alignment = Element.ALIGN_CENTER;
                document.Add(footer);

                // Close document
                document.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"PDF hesabatı yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}