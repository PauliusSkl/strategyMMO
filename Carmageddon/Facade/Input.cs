namespace Carmageddon.Forms.Facade
{
    public class ClickInput
    {
        private string value;

        public ClickInput(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
