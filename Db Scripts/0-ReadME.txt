Proje CodeFirst yaklaşımı ile oluşturulmuştur. Proje 2 şekilde çalıştırılabilir.

1- Proje üzerinden migration atarak.

DataAccessLayer->Concrete->Context.cs dosyasındaki aşağıdaki alan kullanıcının kendi localhost bağlantısındaki
"server" adı ile güncellenmelidir.

optionsBuilder.UseSqlServer("server=DESKTOP-KODJSDM;database=Toyota;integrated security=true;TrustServerCertificate=True");
 
Package Manager Console açılır. Default project "DataAccessLayer" seçilir ve sırasıyla aşağıdaki komutlar çalıştırılır.

add-migration mig1

update-database

İşlemler yapıldıktan sonra Db Scripts klasörü içindeki 3 ve 4 numaralı .txt dosyaları MSSQL üzerinde çalıştırılmalıdır.

2- MSSQL üzerinden tüm işlemler yapılır.

MSSQL üzerinden yeni bir veritabanı oluşturulur.

DataAccessLayer->Concrete->Context.cs dosyasındaki aşağıdaki alan kullanıcının kendi localhost bağlantısındaki
"server" adı ve oluşturduğumuz database adı güncellenmelidir.

optionsBuilder.UseSqlServer("server=DESKTOP-KODJSDM;database=Toyota;integrated security=true;TrustServerCertificate=True");

Ardından klasör içindeki 1-2-3-4 numaralı .txt sırasıyla çalıştırılmalıdır.