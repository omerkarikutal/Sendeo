# Sendeo
Sendeo
Uygulamada 5 adet servis bulunmaktadır. 
OrderService,CustomerService,CategoryService,AuthService,GatewayService
AuthService identity tarafının yapıldığı jwt kullanılmıştır . Cqrs yapısı business tarafta kullanıldı.
Gatewayservice için ocelot yapısı kullanıldı.
Servisler arası iletişim de grpc (sync) yapısı tercih edildi.
Repository Pattern birçok yapıda kullanıldı.
Öncelikle username=test ve password=1234 ile token alarak , order servisine istek atmanız gerekmektedir(bir bug var , şimdilik token almanıza gerek yok.).
Test kısmı için xUnit kısmı kullanıldı.
DataAcess tarafının testleri yapıldı.
Veritabanı olarak mssql kullanıldı.
Orm için Entityframework kullanıldı.
Docker için ayaklandırılmış olan sa user için şifrenin Omer123! olması gerekmektedir. Şifreniz farklı ise , kendi şifrenizi compose dosyasına env alanlarının güncellendiği yerden güncellemeniz gerekmektedir.
Docker üzerinde bütün servisler ayaklandırıldı.
İlerleyen zamanlarda  , Service directory kısmı için Consul yapısı eklenecek.
Loglama için Graylog eklenecek.
