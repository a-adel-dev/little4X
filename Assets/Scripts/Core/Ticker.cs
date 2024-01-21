namespace com.Artillery.Core
{
    public class Ticker
    {
        private float _value;
        private float _elapsed;

        public Ticker(float value)
        {
            _value = value;
        }

        public void UpdateTicker(float time)
        {
            _elapsed += time;
        }

        public void ResetTicker()
        {
            _elapsed = 0;
        }

        public bool IsTickerUp()
        {
            return _elapsed >= _value;
        }

        public float GetRemainingTime()
        {
            return _value - _elapsed;
        }

        public void SetTickerValue(float value)
        {
            _value = value;
        }
    }
}