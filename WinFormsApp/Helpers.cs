namespace WinFormsApp
{
    public static class Helpers
    {
        public static void AppendText(this RichTextBox box, string text, Color? color = null, bool newLine = false)
        {
            box.SuspendLayout();
            box.SelectionColor = color ?? Color.Black;
            box.AppendText(newLine ? $"{text}{Environment.NewLine}" : text);
            box.ScrollToCaret();
            box.ResumeLayout();
        }
    }
}
