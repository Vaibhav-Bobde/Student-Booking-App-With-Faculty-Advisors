namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("FACULTY_APP.Users", "EmailId", c => c.String(maxLength: 255));
            AddColumn("FACULTY_APP.Users", "Fname", c => c.String(maxLength: 255));
            AddColumn("FACULTY_APP.Users", "Lname", c => c.String(maxLength: 255));
            DropColumn("FACULTY_APP.Users", "Uname");
        }
        
        public override void Down()
        {
            AddColumn("FACULTY_APP.Users", "Uname", c => c.String(maxLength: 255));
            DropColumn("FACULTY_APP.Users", "Lname");
            DropColumn("FACULTY_APP.Users", "Fname");
            DropColumn("FACULTY_APP.Users", "EmailId");
        }
    }
}
