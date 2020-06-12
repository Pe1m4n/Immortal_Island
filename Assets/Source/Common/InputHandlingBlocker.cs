namespace Source.Common
{
    public class InputHandlingBlocker
    {
        private InputSource _allowedInputs;
        
        public void SetAllowedInputs(InputSource sources)
        {
            _allowedInputs = sources;
        }

        public bool IsInputSourceAllowed(InputSource source)
        {
            return _allowedInputs.HasFlag(source);
        }
    }
}