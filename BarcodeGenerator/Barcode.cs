using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BarcodeGenerator
{
    public abstract class BarcodeSymbology
    {
        private List<byte> _symbol = new List<byte>();

        internal class SymbolMap<KeyT>
        {
            private Dictionary<KeyT, byte[]> _map = new Dictionary<KeyT, byte[]>();
            public void Add(KeyT key, params byte[] vals)
            {
                _map.Add(key, vals);
            }
            public byte[] this[KeyT key]
            {
                get 
                {
                    byte[] vals;
                    if (_map.TryGetValue(key, out vals))
                        return vals;
                    else
                        throw new InvalidOperationException("Key: " + key.ToString() + " is not included in the current Barcode Symbology Map");
                }
            }
        }

        protected void Add(params byte[] bars)
        {
            _symbol.AddRange(bars);
        }
        public byte[] GetSymbol(string value)
        {
            lock (_symbol) // since this is using a class level variable, make it thread safe 
            {
                _symbol.Clear();
                for (int i = 0; i < QuietLength; i++)
                {
                    _symbol.Add(0);
                }

                ProcessCode(value);
                for (int i = 0; i < QuietLength; i++)
                {
                    _symbol.Add(0);
                }
                return _symbol.ToArray();
            }
        }

        protected abstract int QuietLength { get; }
        protected abstract void ProcessCode(string barcode);
    }

    public enum BarcodeOrientation 
    {
        Horizontal, Vetical 
    }
    
    public class Barcode
    {
        #region Property Symbology : BarcodeSymbology

        private BarcodeSymbology _symbology;
        public BarcodeSymbology Symbology
        {
            get { return _symbology; }
            set { _symbology = value; }
        }

        #endregion

        #region Property Size : SizeF

        private SizeF _size;
        public SizeF Size
        {
            get { return _size; }
            set { _size = value; }
        }

        #endregion

        #region Property Orientation : BarcodeOrientation

        private BarcodeOrientation _orientation;
        public BarcodeOrientation Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }

        #endregion
	
        public Barcode(BarcodeSymbology symbology) : this(symbology, SizeF.Empty, BarcodeOrientation.Horizontal) { }
        public Barcode(BarcodeSymbology symbology, SizeF size) : this(symbology, size, BarcodeOrientation.Horizontal) { }
        public Barcode(BarcodeSymbology symbology, SizeF size, BarcodeOrientation orientation)
        {
            if (symbology == null)
            {
                throw new ArgumentException("Symbology cannot be null.");
            }

            _symbology = symbology;
            _size = size;
            _orientation = orientation;
        }

        public void Draw(Graphics g, RectangleF bounds, BarcodeOrientation orientation, string barcode)
        {
            byte[] symbol = _symbology.GetSymbol(barcode);
            
            float barWidth = (orientation == BarcodeOrientation.Horizontal? bounds.Width : bounds.Height) / symbol.Length;
            float x = bounds.X, y = bounds.Y;

            for (int i = 0; i < symbol.Length; i++)
            {
                switch (orientation)
                {
                    case BarcodeOrientation.Horizontal:
                        if (symbol[i] == 1)
                            g.FillRectangle(Brushes.Black, x, y, barWidth, bounds.Height);

                        x += barWidth;
                        break;
                    case BarcodeOrientation.Vetical:
                        if (symbol[i] == 1)
                            g.FillRectangle(Brushes.Black, x, y, bounds.Width, barWidth);

                        y += barWidth;
                        break;
                }
            }
        }

        public void Draw(Graphics g, RectangleF bounds, string barcode)
        {
            Draw(g, bounds, _orientation, barcode);
        }

        public void Draw(Graphics g, float x, float y, BarcodeOrientation orientation, string barcode)
        {
            Draw(g, new RectangleF(x, y, _size.Width, _size.Height), orientation, barcode);
        }

        public void Draw(Graphics g, float x, float y, string barcode)
        {
            Draw(g, new RectangleF(x, y, _size.Width, _size.Height), _orientation, barcode);
        }

        public void Draw(Graphics g, PointF location, BarcodeOrientation orientation, string barcode)
        {
            Draw(g, new RectangleF(location, _size), orientation, barcode);
        }

        public void Draw(Graphics g, PointF location, string barcode)
        {
            Draw(g, new RectangleF(location, _size), _orientation, barcode);
        }
    }    
}
