using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        // data
        string strBarCode = "01234567891234567";
        string Section = "124";
        string Neighborhood = "Admission";
        string RowVal = "8";
        string SeatVal = "2";
        string dnoname = "HS";
        string EventCode = "Event Code";
        string Price_TAX = "$1,234.56";
        string SectionRowSeat = "123 / 8 / 2";
        string PriceCode = "Price Code";
        string EventLine1 = "EVENT LINE 1";
        string EventLine2 = "EVENT LINE 2";
        string EventLine3 = "EVENT LINE 3";
        string EventLine4 = "EVENT LINE 4";
        string EventLine5 = "EVENT LINE 5";
        string EventLine6 = "EVENT LINE 6";
        string DateTimeLine = "Day July 20, YYYY 6:00PM";

        string Price_TAX = "$1,234.56";
        string SectionRowSeat = "123 / 8 / 2";
        string PriceCode = "Price Code";
        // parameters
        float barcodeSizeX = 2.125f;
        float barcodeSizeY = 0.4f;

        float ticketBaseY = 0.2f;
        float ticketBaseX = 0.2f;
        float BaseOffY = 0.4f;
        float BaseOffX = 0.1f;
        float entryHeight = 0.22f;
        float ticketTitleBaseY = 0.29f;
        float ticketSideBaseY = 0.27f;
        string ticketTemplatePath = "C:\\temp\\eticket\\eticket_16.bmp";
        int barCodeFontSize = 8;
        int ticketFontSize = 10;
        string ticketFontFamily = "Arial";
        StringAlignment ticketAligment = StringAlignment.Center;
        float NeighborOffX = 2.5f;
        float SectionOffX = 3.8f;
        float RowOffX = 4.5f;
        float SeatOffX = 5.1f;
        float NoNameOffX = 5.65f;

        // rotate parameters
        float RotateOffY = -7.4f;
        float RotateOffX = 0.1f;
        float RotateBarcodeOffY = 0.4f;
        float RotateBarcodeOffX = 0.15f;

        public Form1()
        {
            InitializeComponent();
        }

        private void PrintPage(object sender, PaintEventArgs e1)
        {
            Barcode bc2 = new Barcode(new Code128Symbology(), new SizeF(barcodeSizeX, barcodeSizeY)); // useNumericCompression

            ///////////////////// Print Barcode ///////////////////////////////////
            Bitmap image2 = new Bitmap(ticketTemplatePath);
            e1.Graphics.DrawImage(image2, 0, 0);

            Graphics eg = e1.Graphics;
            eg.PageUnit = GraphicsUnit.Inch;

            PointF pt = new PointF(ticketBaseX, ticketBaseY);
            bc2.Draw(eg, pt, strBarCode);
            Brush brush = Brushes.Black;
            pt = new PointF(ticketBaseX + BaseOffX, ticketBaseY + BaseOffY);
            FontFamily ff = new FontFamily(ticketFontFamily);
            Font ft = new Font(ff, barCodeFontSize, FontStyle.Regular);
            eg.DrawString(strBarCode, ft, brush, pt);

            StringFormat sf = new StringFormat();
            sf.Alignment = ticketAligment; 
            ////////////////////////////////////////////////////////////////////////////

            Font ftitle = new Font(ff, ticketFontSize, FontStyle.Bold);
            Font fdata = new Font(ff, ticketFontSize, FontStyle.Regular);
            RectangleF rcf = new RectangleF(ticketBaseX + NeighborOffX, ticketTitleBaseY, 1.2f, entryHeight);
            eg.DrawString(Neighborhood, fdata, brush, rcf, sf);
            ////////////////////////////////////////////////////////////////////////////
            rcf = new RectangleF(ticketBaseX + SectionOffX, ticketTitleBaseY, 1.0f, entryHeight);
            eg.DrawString(Section, fdata, brush, rcf, sf);
            ////////////////////////////////////////////////////////////////////////////
            rcf = new RectangleF(ticketBaseX + RowOffX, ticketTitleBaseY, 1.0f, entryHeight);
            eg.DrawString(RowVal, fdata, brush, rcf, sf);
            ////////////////////////////////////////////////////////////////////////////
            rcf = new RectangleF(ticketBaseX + SeatOffX, ticketTitleBaseY, 1.0f, entryHeight);
            eg.DrawString(SeatVal, fdata, brush, rcf, sf);
            ////////////////////////////////////////////////////////////////////////////

            rcf = new RectangleF(ticketBaseX + NoNameOffX, ticketTitleBaseY, 1.0f, entryHeight);
            eg.DrawString(dnoname, fdata, brush, rcf, sf);
            ///////////// Event Code ////////////////////////////////////////////////////
            float xwide = 2.3f;
            float SideOffY = 0.7f;
            rcf = new RectangleF(ticketBaseX, ticketSideBaseY + SideOffY, xwide, entryHeight);
            eg.DrawString(EventCode, fdata, brush, rcf, sf);
            ///////////// price ////////////////////////////////////////////////////
            float ticketTitleOffY = 1.05f;
            rcf = new RectangleF(ticketBaseX, ticketSideBaseY + ticketTitleOffY, xwide, entryHeight);
            eg.DrawString(Price_TAX, fdata, brush, rcf, sf);
            ///////////// section row seat ////////////////////////////////////////////////////
            ticketTitleOffY = 1.42f;
            rcf = new RectangleF(ticketBaseX, ticketSideBaseY + ticketTitleOffY, xwide, entryHeight);
            eg.DrawString(SectionRowSeat, fdata, brush, rcf, sf);
            ///////////// price code ////////////////////////////////////////////////////
            float ticketPriceOffY = 1.8f;
            rcf = new RectangleF(ticketBaseX, ticketSideBaseY + ticketPriceOffY, xwide, entryHeight);
            eg.DrawString(PriceCode, fdata, brush, rcf, sf);
            ///////////// Event Line 1 - 6 ////////////////////////////////////////////////////
            float ticketLineBaseY = 0.68f;
            float ticketLineBaseX = 2.0f;
            xwide = 5.0f;
            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY, xwide, entryHeight);
            eg.DrawString(EventLine1, fdata, brush, rcf, sf);
            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight, xwide, entryHeight);
            eg.DrawString(EventLine2, fdata, brush, rcf, sf);
            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight * 2, xwide, entryHeight);
            eg.DrawString(EventLine3, fdata, brush, rcf, sf);

            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight * 3, xwide, entryHeight);
            eg.DrawString(EventLine4, fdata, brush, rcf, sf);
            
            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight * 4, xwide, entryHeight);
            eg.DrawString(EventLine5, fdata, brush, rcf, sf);

            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight * 5, xwide, entryHeight);
            eg.DrawString(EventLine6, fdata, brush, rcf, sf);

            rcf = new RectangleF(ticketLineBaseX, ticketLineBaseY + entryHeight * 5 + 0.27f, xwide, entryHeight);
            eg.DrawString(DateTimeLine, fdata, brush, rcf, sf);

            ////////////// Rotate Barcode //////////////////////////////////
            eg.RotateTransform(90);

            PointF ptf = new PointF(RotateOffX, RotateOffY);
            bc2.Draw(eg, ptf, strBarCode);
            ptf = new PointF(RotateOffX + RotateBarcodeOffX, RotateOffY + RotateBarcodeOffY);
            eg.DrawString(strBarCode, ft, brush, ptf);
        }
            

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PrintPage(sender, e);
        }

    }
}
