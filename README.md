**ASP.NET CORE MICROSERVICE E-TRADE PROJECT**

- Bu proje mikroservis mimarisiyle olu�turulmu� bir e-ticaret projesidir. Her bir mikroservis ba��ms�z olarak �al��abilen ve belirli g�revleri yerine getiren ba��ms�z servislerden olu�maktad�r.
- Ana sayfada kategorileri g�r�nt�leyebilir, kategorilere ait �r�nleri listeyebilir, sepetinize ekleyebilir, �r�n detay�na giderek �r�n hakk�ndaki a��klamalar� ve yorumlar� listeleyebilir ve �zel teklifleri g�r�nt�leyebilirsiniz.
- Sepete eklenen �r�nleri Sipari�i Tamamla ile adres ve kargo bilgisi i�in Order ad�m�na y�nlendirir. Kargo adresi varsa g�ncelleyebilir yoksa ekleyebilir ve �deme ad�m�na ge�er. Kart bilgileri girildikten sonra Sipari� Onay� maili g�ndererek siprai� i�lemi tamamlan�r.
- Dosyan�n en alt�nda projeye ait baz� ekran g�r�nt�leri bulunmaktad�r. Daha fazlas� i�in **Frontends -> MultiShop.WebUI -> wwwroot -> assets** klas�r� alt�ndan ula�abilirsiniz.

**Kullan�lan Teknolojiler:**

- .Net 8
- Docker
- Portainer
- MongoDB
- PostgreSQL
- MSSQL
- Redis
- IdentityServer4
- OcelotGateway
- Dapper
- Entity Framework
- AJAX
- Onion Architecture
- CQRS & Mediator Design Pattern
- N-Tier Design Pattern
- Dependency Injection (DI) Design Pattern
- AutoMapper ( Dto - Entity d�n���mleri i�in )
- FluentValidation
- Mimekit ( �deme ad�m� sonras� Sipari� Onay� mail g�nderimi i�in )
- RapidApi ( Ana Sayfada D�viz Kuru ve Hava Durumu bilgisi i�in )

**Mikroservisler**

- T�m mikroservisler kullan�c� giri�ine gerek olsun veya olmas�n token ile koruma alt�na al�nm��t�r.

**1. Catalog Mikroservisi:** Kategoriler ve kategorilere g�re �r�nlerin listelendi�i, �ne ��kan �r�nlerin, �zel indirimlerin, servis standartlar�n�n ve markalar�n listelendi�i ve y�netildi�i mikroservistir.
Bu mikroserviste veriler Mongo DB veritaban�nda saklan�r. Bu mikroservis kullan�c� giri�i yap�larak al�nan token de�erine gerek kalmadan fakat client credential token ile koruma alt�na al�nm��t�r.
Bu mikroservis;

- Site hakk�ndaki bilgileri,
- Kategorileri,
- �ne ��kan �r�nleri,
- �zel teklifleri,
- �r�n detaylar�n� (A��klama, G�rseller),
- Sitenin sunmu� oldu�u servis standartlar�n�,
- �zel indirimleri,
- Markalar�
- �neri, talep veya �ikayetlerin iletilebilece�i bir ileti�im sayfas�n�n g�r�nt�lenmesi, yeni veri eklenmesini, g�ncellenmesini ve silinmesini sa�lar.

**2. Basket Mikroservisi:** Sepete eklenen �r�nleri listeleyebilir, sepete �r�n eklenmesi veya ��kar�lmas�, sepetinizde bulunan �r�nlerin ve toplam fiyat�n hesaplanmas� ve g�sterilmesi g�revlerini yerine getirir.
- Sepete �r�n ekleyebilmek i�in kullan�c�n�n sisteme giri� yapm�� olmas� gerekmektedir. E�er herhangi bir �yelik kayd� yoksa kolay bir �ekilde kay�t olup giri� yapt�ktan sonra sepeti g�r�nt�leyebilir.
- Bu mikroserviste veriler Redis'te tutulmaktad�r. Docker'da aya�a kald�r�lm��t�r cloud ortamda tutulmaktad�r.

**3. Cargo Mikroservisi:** Bu mikroservis N-katmanl� mimari kullan�larak geli�tirilmi�tir. Veriler veritaban� olarak Docker �zerinde aya�a kald�r�lm�� tamamen cloud ortamda bulunan bir MSSQL �zerinde tutulmaktad�r. 
Kargo i�lemlerinin yap�labilmesi i�in kullan�c�n�n sisteme giri� yapm�� olmas� gerekmektedir.

Bu mikroservis;
- kargo �irketlerinin,
- kargo m��terilerinin,
- kargo detaylar�n� ve
- kargo hareketlerinin veri eklenmesi, g�ncellenmesi, ��kar�lmas� ve listelenmesi g�revlerini yerine getirir.

**4. Comment Mikroservisi:** Kullan�c�lar�n �r�nlere ait yorumlar�n� yapmas�n� sa�layan mikroservistir. Veriler veritaban� olarak Docker �zerinde tamamen cloud ortamda aya�a kald�r�lm�� bir MSSQL veritaban� �zerinde tutulmaktad�r.
Bu mikroservis ile;

- Kullan�c�lar bir �r�n�n detaylar�na giderek �r�n hakk�nda yorumlar�n� yapabilirler ve �r�n detay�nda o �r�ne yap�lm�� yorumlar� listeleyebilirler.
- �r�ne yorum yapabilmek i�in kullan�c�n�n giri� yapmas� zorunlu k�l�narak mikroservis token ile koruma alt�na al�nm��t�r.

**5. Discount Mikroservisi:** Bu mikroservis ile indirim kuponu olu�turulabilir ve sepet ekran�nda kupon kodu uygulanarak indirim sa�lanabilir. Bu mikroservis indirim kuponu olu�turulmas�n� sa�lar. �ndirim kuponlar� sisteme giri� yap�ld�ktan sonra Admin paneli �zerinden yap�lmakatd�r.
- Veriler MSSQL veritaban�nda Dapper kullan�larak tutulmaktad�r.

**6. Message Mikroservisi:** Kullan�c�lar�n sistem adminine mesaj g�ndermesini ve gelen mesajlar�n listelenmesini yapmaktad�r. Kullan�c�lar sadece admine mesaj g�nderebilir. Kendi aralar�nda bir mesajla�ma yapamazlar. Mesaj i�lemleri Kullan�c� paneli �zerinden yap�l�r.
- Veriler PostgreSQL veritaban� �zerinde tutulmaktad�r.

**7. Order Mikroservisi:** Bu mikroservis ile kullan�c�n�n adres bilgileri, Sipari� bilgileri ve sipari� detaylar�n�n i�lemleri yap�lmaktad�r.
- Veriler Docker �zerinde aya�a kald�r�lm�� MSSQL veritaban� �zerinde tutulmaktad�r.
- Onion Artitechture, CQRS ve Mediator Design Pattern'leri kullan�larak geli�tirilmi�tir.

**8. Payment Mikroservisi:** Bu mikroservis ile �deme i�lemleri yap�lmaktad�r. bu mikroserviste, di�er mikroservisler �al��maktad�r. Sipari� bilgilerini, Kargo i�lemlerini kaydeder, sepeti temizler ve i�lem sonucunda kullan�c�ya Sipari� Onay� olarak sepetindeki �r�nleri bir mail olarak g�nderir.
- Kart bilgileri kaydedilmedi�inden herhangi bir veritaban� bulunmamaktad�r.

**9. Identity Server:** IdentityServer4.AspNetIdentity k�t�phanesi ile mikroservislere ve kullan�c� giri�lerine OAuth2.0 ile toke korumas� sa�lar. Veritaban� Docker �zerinde aya�a kald�r�lm��t�r.

**10. ApiGateway:** Presentation taraf�nda mikroservislere do�rudan ba�lant� yap�lmak yerine OcelotGateway kulln�lm��t�r. UI taraf�ndan gelen istekler Ocelot'a iletilmektedir. Ocelot kara vererek ilgili mikroservise y�nlendirmektedir.

**Projeden Ekran G�r�nt�leri**
- Daha fazlas� i�in **Frontends -> MultiShop.WebUI -> wwwroot -> assets** klas�r� alt�ndan ula�abilirsiniz.

![Ana Sayfa](Frontends/MultiShop.WebUI/wwwroot/assets/homepage1.png)
![Ana Sayfa](Frontends/MultiShop.WebUI/wwwroot/assets/homepage4.png)
![Ana Sayfa](Frontends/MultiShop.WebUI/wwwroot/assets/shoppingcart.png)
![Ana Sayfa](Frontends/MultiShop.WebUI/wwwroot/assets/adminpanel1.png)
![Ana Sayfa](Frontends/MultiShop.WebUI/wwwroot/assets/userpanel1.png)