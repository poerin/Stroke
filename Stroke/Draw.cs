using System;
using System.Drawing;

namespace Stroke
{
    public class Draw
    {
        private readonly IntPtr client;
        private readonly IntPtr canvas;
        private readonly IntPtr pen;

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
            API.SelectObject(canvas, pen);
            API.MoveToEx(canvas, start.X - rect.Left, start.Y - rect.Top, IntPtr.Zero);
            API.LineTo(canvas, end.X - rect.Left, end.Y - rect.Top);
        }

        public void Dispose()
        {
            API.ReleaseDC(client, canvas);
        }

    }
}
