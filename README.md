Console App
Ado.Net 
Dapper
EFCore




EFCore မှာ Code first and Database First ဆိုပီး ရှိတယ် 
Code First ဆိုတာက code ကနေ ရေးလိုက်တာနဲ့ database မှာ table ဆောက်တာ  
Database First ဆိုတာက ရှိပီးသား database က ဟာကို C# မှာ ပြန်ယူသုံးတာ


https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
above link is to read about Scaffold-DbContext Command

Scaffold-DbContext "Server=LAPTOP-1PC0MA3L\MSSQLSERVER2022;Database=DotNetTraningBatch4;User ID=sa;Password=sa@123;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DotNetTraningBatchAppDbContext
scaffold-DbContext ကို သုံးတော့မယ်ဆိုရင် Microsoft.EntityFrameworkCore.Tool ဆိုတဲ့ package ကိုထပ်သွင်းပေးရတယ် 