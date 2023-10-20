using System.Drawing;
using System.Windows.Forms;

public class ResizableRectangle
{
    public Rectangle Rectangle { get; set; }
    public PictureBox PictureBox { get; set; }

    public ResizableRectangle(PictureBox pictureBox, Rectangle rectangle)
    {
        PictureBox = pictureBox;
        Rectangle = rectangle;
    }

    public void DrawRectangle()
    {
        if (PictureBox != null)
        {
            using (Graphics g = PictureBox.CreateGraphics())
            {
                g.DrawRectangle(Pens.Black, Rectangle);
            }
        }
    }


    // You can add other methods to move, update, or interact with the rectangle as needed.
}
