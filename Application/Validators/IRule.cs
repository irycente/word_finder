namespace Application.Validators
{
    public interface IRule
    {
        string ErrorMessage { get; }
        void Validate();
    }
}
