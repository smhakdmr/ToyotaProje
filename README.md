Toyota Case Project

Database: MsSQL Server

Backend: .NET 6 ve üstü

Authentication: Custom bir identity oluşturulmuştur. Proje Login ekranı ile açılır ve login olunmadan hiçbir sayfaya
erişim sağlanamaz. Proje her restart olduğunda tekrar login olunacak şekilde tasarlanmıştır.

User Bilgisi : 

Email : admin@admin.com

Şifre : Admin123.

Proje içersinde mevcut servis kayıtlarını görüntüleyebilir, silebilirsiniz. Yeni bir kullanıcı oluşturabilirsiniz.

Projede N Katmanlı Mimari Kullanılmıştır. Katmanlarımız kısaca aşağıdaki gibidir.

 - Entity Layer
	- Projemizde bulunan tablolar bu katmanda bulunmaktadır.
 
 - Data Access Layer
	- CRUD Operasyonları ve Db Context'imiz bu katmanda bulunmaktadır.
 
 - Business Layer
	- validasyonlarımız ve Manager'larımız bu katmanda bulunmaktadır.
 
 - Presentation Layer
	- UI ve Controller'ımız bu katmanda bulunmaktadır.
	
 - Api

UI tarafında Bootstrap kullanılmıştır.
