namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembership : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, Name,  SignupFee, DurationInMonth, DiscountRate) VALUES (1, 'Pay as You Go', 0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, Name,  SignupFee, DurationInMonth, DiscountRate) VALUES (2, 'Monthly', 300,12,20)");
            Sql("INSERT INTO MembershipTypes(Id, Name,  SignupFee, DurationInMonth, DiscountRate) VALUES (3, 'Quarterly', 0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, Name,  SignupFee, DurationInMonth, DiscountRate) VALUES (4, 'Yearly', 300,12,20)");

        }
        
        public override void Down()
        {
        }
    }
}
