-- public."__EFMigrationsHistory" definition

-- Drop table

-- DROP TABLE public."__EFMigrationsHistory";

CREATE TABLE public."__EFMigrationsHistory" (
	"MigrationId" varchar(150) NOT NULL,
	"ProductVersion" varchar(32) NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

-- public."Roles" definition

-- Drop table

-- DROP TABLE public."Roles";

CREATE TABLE public."Roles" (
	"Id" uuid NOT NULL,
	"RoleName" text NULL,
	"DateCreated" timestamp NULL,
	"UserCreated" text NULL,
	"DateUpdated" timestamp NULL,
	"UserUpdated" text NULL,
	CONSTRAINT "PK_Roles" PRIMARY KEY ("Id")
);

-- public."Users" definition

-- Drop table

-- DROP TABLE public."Users";

CREATE TABLE public."Users" (
	"Id" uuid NOT NULL,
	"Name" text NULL,
	"LastName" text NULL,
	"RoleId" uuid NULL,
	"DateCreated" timestamp NULL,
	"UserCreated" text NULL,
	"DateUpdated" timestamp NULL,
	"UserUpdated" text NULL,
	CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);
CREATE INDEX "IX_Users_RoleId" ON public."Users" USING btree ("RoleId");


-- public."Users" foreign keys

ALTER TABLE public."Users" ADD CONSTRAINT "FK_Users_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id");

-- public."Companies" definition

-- Drop table

-- DROP TABLE public."Companies";

CREATE TABLE public."Companies" (
	"Id" uuid NOT NULL,
	"CompanyName" text NULL,
	"UserId" uuid NULL,
	"DateCreated" timestamp NULL,
	"UserCreated" text NULL,
	"DateUpdated" timestamp NULL,
	"UserUpdated" text NULL,
	CONSTRAINT "PK_Companies" PRIMARY KEY ("Id")
);
CREATE INDEX "IX_Companies_UserId" ON public."Companies" USING btree ("UserId");


-- public."Companies" foreign keys

ALTER TABLE public."Companies" ADD CONSTRAINT "FK_Companies_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");