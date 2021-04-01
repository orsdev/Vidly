namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignupFee, DurationInMonth, DiscountRate) VALUES (1, 0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignupFee, DurationInMonth, DiscountRate) VALUES (2, 300,12,20)");
            Sql("INSERT INTO MembershipTypes(Id, SignupFee, DurationInMonth, DiscountRate) VALUES (3, 0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignupFee, DurationInMonth, DiscountRate) VALUES (4, 300,12,20)");
            Sql("INSERT INTO MembershipTypes(Id, SignupFee, DurationInMonth, DiscountRate) VALUES (5, 0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
