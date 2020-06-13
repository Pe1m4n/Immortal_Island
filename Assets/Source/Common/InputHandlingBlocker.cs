namespace Source.Common
{
    public class InputHandlingBlocker
    {
        private InputSource _allowedInputs;

        public InputHandlingBlocker()
        {
            _allowedInputs = InputSource.Cannon;
        }
        public void SetAllowedInputs(InputSource sources)
        {
            _allowedInputs = sources;
        }

        public bool IsInputSourceAllowed(InputSource source)
        {
            return true;
        }
    }
}