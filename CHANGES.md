# CHANGES

## Unit test altyapısı ve testler

### Yapılanlar
- **Yeni proje:** `TSC.Entity.Tests` (SDK-style csproj) oluşturuldu ve `TSCWinSoln.sln`'e eklendi.
- **Testler:**
  - `CartTests.cs` – `Cart` sınıfının tüm public metotları (`addItem`, `removeItem`, `applyCoupon`,
    `getCouponDiscount`, `getCampaignDiscount`, `getTotalAmountAfterDiscounts`, `getDeliveryCost`):
    olağan durumlar, sınır değerler (min tutara eşit olma vb.) ve hata durumları.
  - `EntityConstructorTests.cs` – `Category`, `Product`, `Coupon`, `Campaign`, `ShoppingChartItem`
    constructor eşlemeleri ve `Discount` kalıtımı.
- Üretim kodunda **hiçbir değişiklik yapılmadı**.

### Kararlar
- **Framework: xUnit (2.9.x) + Microsoft.NET.Test.Sdk.** Repoda test framework yoktu; .NET ekosisteminde en yaygın
  seçenek xUnit olduğu için seçildi.
- **TargetFramework: `net462`.** `TSC.Entity` `net461` hedefliyor; güncel test araçları en az `net462` destekliyor ve
  `net462` projesi `net461` kütüphanesine referans verebilir. `Microsoft.NETFramework.ReferenceAssemblies` paketi
  eklendi ki test projesi hedefleme paketi olmadan da derlenebilsin.
- **Kapsam yalnızca `TSC.Entity`.** İş mantığının tamamı `Cart` içinde; `TSC.WinForm` formları ince UI kodu
  (`MessageBox`, `DataGridView`, form geçişleri). Formlardan mantık çıkarmak davranış değiştirme riski taşıdığı
  ve kazancı düşük olduğu için refactor yapılmadı. Refactor'a gerek kalmadı çünkü `Cart` zaten test edilebilir.
- **Testler mevcut davranışı sabitler, düzeltmez.** Şüpheli davranışlar testlerde yorumla işaretlendi (aşağıya bakın).

### Doğrulama
- macOS'ta .NET Framework çalıştırılamadığı için, repo dışında (`/tmp`) aynı `TSC.Entity/*.cs` ve test dosyalarını
  derleyen geçici bir `net8.0` projesiyle test edildi: **40/40 test geçti.**
- Gerçek `TSC.Entity.Tests` (`net462`) projesi burada derlenemedi: legacy `TSC.Entity.csproj` .NET Framework 4.6.1
  hedefleme paketini istiyor (Windows / Visual Studio'da mevcut). Windows'ta `dotnet test` veya VS Test Explorer ile
  çalıştırılması gerekir.

### Testlerle belgelenen, düzeltilmesi önerilen davranışlar
1. `getTotalAmountAfterDiscounts` indirimli tutarı değil **toplam indirimi** döndürüyor.
2. `getDeliveryCost` teslimat maliyetini değil **indirim sonrası sepet tutarını** döndürüyor; sonuç negatife düşebiliyor.
3. Kampanyadaki `MinProductQuantity`, ürün adedi yerine kategorideki **farklı sepet satırı sayısıyla** karşılaştırılıyor.
4. Kampanyalar alt kategorileri kapsamıyor (kategori referans eşitliğiyle kontrol ediliyor).
5. `MinProductQuantity = 0` olan tutar kampanyası boş sepete de uygulanıyor.
6. Aynı kupon birden fazla kez uygulanabiliyor.
7. `removeItem` sepette olmayan ürün için `InvalidOperationException` fırlatıyor.
8. Ürünler başlığa göre değil referansa göre eşleşiyor (aynı başlıklı iki `Product` ayrı satır oluşturur).

### Test edilmeyen ama fark edilen hata (UI)
- `ShowCart.AddCoupon_Click` içindeki döngü `i > 0` koşulu yüzünden **0. indeksteki seçili kuponu atlıyor**; tek kupon
  seçildiğinde hiçbir kupon uygulanmıyor. Davranış değişikliği olacağı için düzeltilmedi.
