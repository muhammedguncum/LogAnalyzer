# LogAnalyzer

Bu proje, C# ile dosya okuma (File I/O) ve metin ayrıştırma (parsing) temellerini pratik yapmak amacıyla geliştirilmiş basit bir konsol uygulamasıdır. 

Uygulamanın temel amacı, karmaşık bir sistem üretmek değil; verileri bellekte tutmak için uygun veri yapılarını (`Dictionary`) kullanmayı ve bir metin dosyasını satır satır işleme mantığını koda dökmektir.

## Ne Yapıyor?
1. Belirtilen bir `.txt` (log) dosyasını okur.
2. `String.Split()` metodu ile her satırı parçalayarak içerisindeki **IP Adresi**, **İstek Yolu (Path)** ve **HTTP Durum Kodunu** ayıklar.
3. Hatalı veya eksik formatlanmış satırları `try-catch` bloğu ile yakalayarak programın çökmesini engeller.
4. `Dictionary<string, int>` kullanarak eşsiz IP adreslerini gruplar, her IP'nin toplam istek (request) sayısını hesaplar ve konsola yazdırır.

## Nasıl Çalıştırılır?
* Proje dizininde `server_logs.txt` adında bir dosya bulunduğundan emin olun.
* Visual Studio üzerinden çalıştırabilir veya terminalde proje dizinindeyken `dotnet run` komutunu kullanabilirsiniz.

## Örnek Kullanım ve Çıktı

**Girdi (`server_logs.txt` içeriği):**
```text
192.168.1.10 - [19/Apr/2026:10:00:01] "GET /index.html HTTP/1.1" 200
10.0.0.5 - [19/Apr/2026:10:05:12] "GET /about.html HTTP/1.1" 404
192.168.1.10 - [19/Apr/2026:10:06:00] "POST /login HTTP/1.1" 500
```

**Çıktı:
Program başladı...

IP: 192.168.1.10 | PATH: /index.html | STATUS: 200
IP: 10.0.0.5 | PATH: /about.html | STATUS: 404
IP: 192.168.1.10 | PATH: /login | STATUS: 500

--- IP TRAFFIC ---
192.168.1.10 → 2 request
10.0.0.5 → 1 request

Bitti.
