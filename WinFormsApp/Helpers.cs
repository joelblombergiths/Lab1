namespace WinFormsApp
{
    public static class Helpers
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool addNewLine = false)
        {
            box.SuspendLayout();
            box.SelectionColor = color;
            box.AppendText(addNewLine ? $"{text}{Environment.NewLine}" : text);
            box.ScrollToCaret();
            box.ResumeLayout();
        }
    }
}
