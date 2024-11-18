using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class BankAccount
{
    public int Id { get; set; }
    
    public string Image { get; set; }
    
    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string IBAN { get; set; }
    
    public string BranchCode { get; set; }

    public string AccountNumber {get ; set;}
}