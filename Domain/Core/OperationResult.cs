namespace Domain.Core
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsValid = true;
            Errors = new List<Error>();
        }
        public OperationResult(bool isValid)
        {
            IsValid = isValid;
            Errors = new List<Error>(); 
        }

        public bool IsValid { get; set; }
        public List<Error> Errors { get; set; }

        public void Add(OperationResult result)
        {
            if (result.IsValid != true)
            {
                result.IsValid = result.IsValid;
                Errors.AddRange(result.Errors);
            }
        }

        public static OperationResult operator +(OperationResult left, OperationResult right)
        {
            if (left == null) return right;
            if (right == null) return left;

            left.IsValid = left.IsValid && right.IsValid;
            left.Errors.AddRange(right.Errors);

            return left;
        }
    }
}
