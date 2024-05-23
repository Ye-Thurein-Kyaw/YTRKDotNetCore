Console App
Ado.Net 
Dapper
EFCore


EFCore မှာ Code first and Database First ဆိုပီး ရှိတယ် 
Code First ဆိုတာက code ကနေ ရေးလိုက်တာနဲ့ database မှာ table ဆောက်တာ  
Database First ဆိုတာက ရှိပီးသား database က ဟာကို C# မှာ ပြန်ယူသုံးတာ

** pj တစ်ခုဆောက်မယ်ဆိုရင် လိုအပ်တဲ့ package သွင်း။ Connection String ထည့်။ DB ကိုလဲ ထည့်ရမယ်


https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
above link is to read about Scaffold-DbContext Command

Scaffold-DbContext "Server=LAPTOP-1PC0MA3L\MSSQLSERVER2022;Database=DotNetTraningBatch4;User ID=sa;Password=sa@123;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DotNetTraningBatchAppDbContext
scaffold-DbContext ကို သုံးတော့မယ်ဆိုရင် Microsoft.EntityFrameworkCore.Tool ဆိုတဲ့ package ကိုထပ်သွင်းပေးရတယ် 

//async and await note
code မှာ async ပါတယ်ဆို  ဒီနေရာမှာ await ဆို တာကိုဖြုတ်လိုက်မယ်ဆိုရင် response က Task  ဆိုပီးပြောင်းသွားမယ်
Task က ဘာကြီးလဲဆိုတော့ အလုပ်တစ်ခုအနေနဲ့ဘဲ့ ဖြစ်သွားမာ တကယ်မလုပ်သွားဘူး လုပ်စေချင်ရင် await ပါမှ လုပ်လုပ်မှာ
Task ဖြစ်နေတဲ့ဟာကို run စေချင်တယ်ဆိုရင် task.RunSynchronously(); ဆိုမှ run သွားမာ