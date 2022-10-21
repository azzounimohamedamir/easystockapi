using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class add_rols_to_users_organisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", "13" },
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", "13" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce66fecc-9afe-4ec0-a531-f7413f196d5a", "36d2f55d-d564-4f25-a6fd-c45c818eca20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aff2cb9c-c995-460e-996f-6ab5e92e882f", "af732bf3-0292-4a37-9dba-58df75e65cad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59fbc085-fd79-4694-a309-587a26ff9b64", "66c55844-fa86-4b88-b355-3110dbd95084" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3e7411e4-6df1-4d9d-9d1b-3f0447a40c9b", "09233bd7-1df4-4216-bc8c-5284112f00a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cc4c9331-175d-43e3-8f1b-bee23ad96a31", "bb60f6a1-01ea-4426-a709-cb72bfd442eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96509a78-63ea-4b65-978b-31490632c1da", "d42612d2-e47f-4091-b841-9e765cd49216" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b81e27ef-a5b6-4e0c-8cc1-d981a88801df", "90ed9286-99b4-4041-a875-a9f028aaf1ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "745973ee-46ad-45d3-91e7-2fe2f821413c", "236a2040-1ad3-40cc-b8ea-4c9c420c0cdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46911091-2fb8-4b55-91d8-bf2ddbc09ed8", "9a501432-fe51-4887-8224-80e48da76526" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfeb268b-861a-4f97-861c-bd079c145a99", "d9996132-b26e-4fa4-b3ab-6010dbf6570f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "add9d794-6111-4588-ac2d-d530f7cf5583", "28c1aabb-4db0-4e11-89f7-12fb863fdec5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aaec72da-294a-4841-be79-da4b161ada87", "70b26dd2-6c30-42cb-8d0d-f1dbf8ee037c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "87c2e242-ddab-40d7-8cb9-42fd05c50227", "6ce32e1b-cbd2-4e61-b948-bfa773f73bb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "23affc0d-1ba0-43b0-91a1-a865d45412c9", "8a30ce33-7525-416d-be07-070a587fd566" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1ad899a-8b06-4939-8338-e787a1c1d12e", "9ea64682-9652-4125-a359-a9ada6aa5e24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21a1d647-8aff-4135-abfc-fc1b741c9a7c", "7b0675bc-ba59-4e50-806a-8155cda851af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ab7a751-e24f-4edb-8a05-faf58f8606ea", "a42e253a-c876-4f49-a5d3-cbeb7262bc98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", "13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ba89dc5f-dfd1-4c87-9372-233c611cc756", "13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c3f82f3-c303-4a9c-a32e-3e6b8f08833a", "59db171f-d311-4e2a-8a51-af79e382a4e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55b65889-c521-44fd-a535-ed7d26753544", "ae66e06d-0d30-41d7-be85-7961c3b9c82f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "124d877b-610f-4f15-8a68-ff01aad8ede6", "ddf6c560-a62d-4705-8c66-7792e5897470" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c00c8278-7044-4c64-bfde-e5f4d0b2af35", "e2b677d6-9ba9-47ac-bf60-a6bfae489e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d451e632-5900-4b7b-80f7-f0e3d7805cec", "3b26ceea-5a1c-41ef-a57e-d2febef7da02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30782c4a-210c-480c-bdbd-66b773d52bda", "ccc723f9-4de1-4d54-86c7-921cc8b5a753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "829999fd-4445-4df2-a4e2-269aecbe1b54", "c33b7fe1-770a-4e27-a142-5664afeb3792" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99410dd7-84fc-42cc-bdcf-491b42b1a5a0", "a54a4beb-8a6b-4fe9-a0f7-be613ce3f86b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2cb1c725-76bc-4c09-9ff1-12b8034f7f79", "303db0a7-3fca-4162-941f-307cea63df47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7801c133-0a6b-4d3d-a0b3-143602783f32", "488282f7-81b2-4331-be6c-9531b542fda8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "820972b4-f134-42e3-931a-81abe4c6bf2b", "e35e5b06-c21c-4a23-971b-a1cefcd96e36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "255997c6-9c1c-46d6-9485-14bfd6a466d7", "949c2c2b-be59-4318-9df0-4308a1a8585f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fa1ead0-ab50-44f1-9269-c0e329068388", "8d2d065b-cad8-4c16-a1f4-d380505d50d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7fe7dc2-7c28-4cdc-9025-fab4311bc56f", "8266828b-09a8-456c-abc7-ab04d9164323" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1867d6c6-daac-46dd-ba8d-718eb4a6ff54", "c97d16cf-107f-4343-9a0a-4c59c46f3c09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e6e87e2-ffc6-4731-948c-52d44dc937d0", "339026af-bd34-49e5-b395-bdd828a800ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1691d1d2-6f13-44c9-805d-991d1b9dc36f", "0a8b78f7-d74a-4dbf-a8c7-56888bf87fb4" });
        }
    }
}
