namespace Employees
{
    public class StringCalculator
    {

        public object Add(string parameter)
        {            
            int sum = 0;
            var values = parameter.Split(',');
            foreach (var value in values)
            {
                if(!string.IsNullOrEmpty(value))
                {
                    sum += int.Parse(value);
                }
            }
            return sum;
        }
    }
}