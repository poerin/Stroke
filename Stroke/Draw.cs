using System;
using System.Drawing;

namespace Stroke
{
    public class Draw : IDisposable
    {
        private readonly IntPtr client;
        private readonly IntPtr canvas;
        private readonly IntPtr pen;
        private IntPtr originalPen;
        private bool disposed = false;

        public Draw(IntPtr client, IntPtr pen)
        {
            this.client = client;
            canvas = API.GetDC(client);
            this.pen = pen;
        }

        public void DrawPath(Point start, Point end)
        {
            API.RECT rect;
            API.GetWindowRect(client, out rect);
            originalPen = API.SelectObject(canvas, pen);
            API.MoveToEx(canvas, start.X - rect.Left, start.Y - rect.Top, IntPtr.Zero);
            API.LineTo(canvas, end.X - rect.Left, end.Y - rect.Top);
        }

        public void Clear()
        {
            API.RECT rect;
            API.GetWindowRect(client, out rect);
            API.InvalidateRect(client, ref rect, true);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                if (originalPen != IntPtr.Zero)
                    API.SelectObject(canvas, originalPen);
                if (canvas != IntPtr.Zero)
                    API.ReleaseDC(client, canvas);
                disposed = true;
            }

        }

    }
}
