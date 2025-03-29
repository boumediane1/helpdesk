insert into "AspNetUsers" ("Id",
                           "Name",
                           "UserName",
                           "NormalizedUserName",
                           "EmailConfirmed",
                           "PhoneNumberConfirmed",
                           "TwoFactorEnabled",
                           "LockoutEnabled",
                           "AccessFailedCount",
                           "PasswordHash",
                           "SecurityStamp")
values ('admin',
        'Admin',
        'admin',
        'ADMIN',
        false,
        false,
        false,
        false,
        0,
        'AQAAAAIAAYagAAAAEDlJLlF/WCAqFVFqXtmeaFQtTqlwoqP+Vm9MwUUavPLh0tPe1T0npJKSvp0VcgwlKg==',
        'SecurityStamp');

insert into "AspNetRoles" ("Id", "Name", "NormalizedName")
values ('admin', 'Admin', 'ADMIN'),
       ('member', 'Member', 'MEMBER');

insert into "AspNetUserRoles" ("UserId", "RoleId")
values ((select "Id" from "AspNetUsers" where "UserName" = 'admin'),
        (select "Id" from "AspNetRoles" where "Name" = 'Admin'));