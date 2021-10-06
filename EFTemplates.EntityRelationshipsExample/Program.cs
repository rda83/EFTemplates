
/* Варианты описания связи один ко многим
* 
* Вариант 1. У родителя есть список подчиненных объектов, в подчиненном классе ничего не указано (CreditProductsGroups 1-* CreditProducts)
* Сгенерированный скрипт SQL:
*
* Таблица 1:														Таблица 2:
* CREATE TABLE [CreditProductsGroups] (								CREATE TABLE [CreditProducts] (
*     [Id] bigint NOT NULL IDENTITY,										[Id] bigint NOT NULL IDENTITY,
*     CONSTRAINT [PK_CreditProductsGroups] PRIMARY KEY ([Id])				[Name] nvarchar(max) NULL,
* );																		[CreditProductsGroupId] bigint NULL,
* 																		    CONSTRAINT [PK_CreditProducts] PRIMARY KEY ([Id]),
* 																		    CONSTRAINT [FK_CreditProducts_CreditProductsGroups_CreditProductsGroupId] FOREIGN KEY ([CreditProductsGroupId]) REFERENCES [CreditProductsGroups] ([Id]) ON DELETE NO ACTION
* 																	);																
* ON DELETE NO ACTION
*
* ///////////////////////////////////////////////////////////////////////////////////////////////////////////																
* Вариант 2. У родителя есть список подчиненных объектов, в подчиненном классе есть навигационная ссылка (ServiceEngineer 1-* ATM machine)
* Сгенерированный скрипт SQL:
*
* Таблица 1:															Таблица 2:
* CREATE TABLE [ServiceEngineers] (									CREATE TABLE [ATMMachines] (
*     [Id] bigint NOT NULL IDENTITY,		    							[Id] bigint NOT NULL IDENTITY,
*     [Name] nvarchar(max) NULL,											[ServiceEngineerId] bigint NULL,
*     CONSTRAINT [PK_ServiceEngineers] PRIMARY KEY ([Id])					CONSTRAINT [PK_ATMMachines] PRIMARY KEY ([Id]),
* );																		CONSTRAINT [FK_ATMMachines_ServiceEngineers_ServiceEngineerId] FOREIGN KEY ([ServiceEngineerId]) REFERENCES [ServiceEngineers] ([Id]) ON DELETE NO ACTION
*																	);
* ON DELETE NO ACTION
*
* ///////////////////////////////////////////////////////////////////////////////////////////////////////////
* Вариант 3. У родителя есть список подчиненных объектов, в подчиненном классе есть навигационная ссылка и идентификатор родителя (Account owner 1-* Account)
* Сгенерированный скрипт SQL:
*
* Таблица 1:															Таблица 2:
* CREATE TABLE [AccountOwners] (										CREATE TABLE [Accounts] (
*     [Id] bigint NOT NULL IDENTITY,										[Id] bigint NOT NULL IDENTITY,
*     [Name] nvarchar(max) NULL,											[AccountOwnerId] bigint NOT NULL,
*     CONSTRAINT [PK_AccountOwners] PRIMARY KEY ([Id])					    [AccountNumber] nvarchar(max) NULL,
* );																		CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]),
* 																		    CONSTRAINT [FK_Accounts_AccountOwners_AccountOwnerId] FOREIGN KEY ([AccountOwnerId]) REFERENCES [AccountOwners] ([Id]) ON DELETE CASCADE
* 																	);
* ON DELETE CASCADE														
* 
* ///////////////////////////////////////////////////////////////////////////////////////////////////////////
* Вариант 4. У родителя есть список подчиненных объектов, в подчиненном классе есть идентификатор родителя (Bank cells storage 1-* Bank deposit box) 
* Сгенерированный скрипт SQL:
* 
* Таблица 1:															Таблица 2:
* CREATE TABLE [BankCellsStorages] (									CREATE TABLE [BankDepositBoxes] (
*     [Id] bigint NOT NULL IDENTITY,										[Id] bigint NOT NULL IDENTITY,
*     [Addres] nvarchar(max) NULL,										[BankCellsStorageId] bigint NOT NULL,
*     CONSTRAINT [PK_BankCellsStorages] PRIMARY KEY ([Id])				CONSTRAINT [PK_BankDepositBoxes] PRIMARY KEY ([Id]),
* );																		CONSTRAINT [FK_BankDepositBoxes_BankCellsStorages_BankCellsStorageId] FOREIGN KEY ([BankCellsStorageId]) REFERENCES [BankCellsStorages] ([Id]) ON DELETE CASCADE
* 																	);
* ON DELETE CASCADE
*/

/* Произвольное имя поля для внешней ссылки
 * 
 * modelBuilder.Entity<PaymentOrdersRegister>()
 *  .HasMany(s => s.PaymentOrders)
 *  .WithOne(q => q.PaymentOrdersRegister)
 *  .HasForeignKey(q => q.RegisterCode);
 *  
 * Сгенерированный скрипт SQL:
 *
 * Таблица 1:	                                                        Таблица 2:
 * CREATE TABLE [PaymentOrdersRegisters] (								CREATE TABLE [PaymentOrders] (
 *   [Id] bigint NOT NULL IDENTITY,									        [Id] bigint NOT NULL IDENTITY,
 *   CONSTRAINT [PK_PaymentOrdersRegisters] PRIMARY KEY ([Id])			    [RegisterCode] bigint NOT NULL,
 * );																		CONSTRAINT [PK_PaymentOrders] PRIMARY KEY ([Id]),
 *																		CONSTRAINT [FK_PaymentOrders_PaymentOrdersRegisters_RegisterCode] FOREIGN KEY ([RegisterCode]) REFERENCES [PaymentOrdersRegisters] ([Id]) ON DELETE CASCADE
 *																		);	 
 */

/* Описание связи многие ко многим (без хранения дополнительных данных)
 * Security officer *-* Account owner
 * 
 * Сгенерированный скрипт SQL:
 * 
 * CREATE TABLE [SecurityOfficers] (
 *   [Id] bigint NOT NULL IDENTITY,
 *   CONSTRAINT [PK_SecurityOfficers] PRIMARY KEY ([Id])
 * );
 * GO
 *
 * CREATE TABLE [AccountOwnerSecurityOfficer] (
 *   [AccountOwnersId] bigint NOT NULL,
 *   [SecurityOfficersId] bigint NOT NULL,
 *   CONSTRAINT [PK_AccountOwnerSecurityOfficer] PRIMARY KEY ([AccountOwnersId], [SecurityOfficersId]),
 *   CONSTRAINT [FK_AccountOwnerSecurityOfficer_AccountOwners_AccountOwnersId] FOREIGN KEY ([AccountOwnersId]) REFERENCES [AccountOwners] ([Id]) ON DELETE CASCADE,
 *   CONSTRAINT [FK_AccountOwnerSecurityOfficer_SecurityOfficers_SecurityOfficersId] FOREIGN KEY ([SecurityOfficersId]) REFERENCES [SecurityOfficers] ([Id]) ON DELETE CASCADE
 * );
 * 
 */

/* Описание связи многие ко многим (c хранением дополнительных данных)
 * AccountOwner *-* SecurityIncident
 * 
 *   modelBuilder.Entity<AccountOwner>()
 *       .HasMany(s => s.SecurityIncidents)
 *       .WithMany(b => b.AccountOwners)
 *       .UsingEntity<AccountOwnerSecurityIncident>(bs => bs.HasOne<SecurityIncident>().WithMany(),
 *           bs => bs.HasOne<AccountOwner>().WithMany())
 *       .Property(bs => bs.DateOfIncident)
 *       .HasDefaultValueSql("getdate()");.
 *
 * Сгенерированный скрипт SQL:
 *
 * CREATE TABLE[SecurityIncidents] (
 *   [Id] bigint NOT NULL IDENTITY,
 *   CONSTRAINT[PK_SecurityIncidents] PRIMARY KEY ([Id])
 * );
 * GO
 *
 * CREATE TABLE [AccountOwnerSecurityIncident] (
 *   [AccountOwnerId] bigint NOT NULL,
 *   [SecurityIncidentId] bigint NOT NULL,
 *   [DateOfIncident] datetime2 NOT NULL DEFAULT (getdate()),
 *   CONSTRAINT[PK_AccountOwnerSecurityIncident] PRIMARY KEY([AccountOwnerId], [SecurityIncidentId]),
 *   CONSTRAINT[FK_AccountOwnerSecurityIncident_AccountOwners_AccountOwnerId] FOREIGN KEY([AccountOwnerId]) REFERENCES[AccountOwners]([Id]) ON DELETE CASCADE,
 * CONSTRAINT[FK_AccountOwnerSecurityIncident_SecurityIncidents_SecurityIncidentId] FOREIGN KEY ([SecurityIncidentId]) REFERENCES[SecurityIncidents]([Id]) ON DELETE CASCADE
 * );
*/

/* Описание связи один к одному
 * Account owner 1-1 Security key
 * 
 * CREATE TABLE[SecurityKeys] (
 *   [Id] bigint NOT NULL IDENTITY,
 *   [AccountOwner] bigint NOT NULL,
 *   CONSTRAINT[PK_SecurityKeys] PRIMARY KEY ([Id])
 * );
 * GO
 *
 * CREATE INDEX [IX_AccountOwners_SecurityKeyId] ON[AccountOwners]([SecurityKeyId]);
 * GO
 *
 * ALTER TABLE [AccountOwners] ADD CONSTRAINT[FK_AccountOwners_SecurityKeys_SecurityKeyId] FOREIGN KEY ([SecurityKeyId]) REFERENCES[SecurityKeys]([Id]) ON DELETE NO ACTION;
 * GO
*/

using System;

namespace EFTemplates.EntityRelationshipsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
