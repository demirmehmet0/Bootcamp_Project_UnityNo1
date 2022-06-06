using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextAnim : MonoBehaviour
{
    //VARIABLES
    private TMP_Text _Text;
    //<param name="_Text">
    //Bu scriptin atandığı text objesini tutmak için oluşturulan değişken
    //</param>
    private bool isUpOrDown = true;
    //<param name="isUpOrDown">
    //Textin font boyutu artacak mı azalacak mı olduğunu belirleyen bool
    //default olarak true, textin fontu belirlenen değerden(32) küçük ise true büyük ise false değerini alır
    //</param>
    private bool isLoadingAnim = false;
    //<param name="isLoading">
    //Scriptin atıldıpı textin yükleniyor animi mi(3 nokta) yoksa
    //büyüyüp küçülme animi mi olduğunu belirleyen bool(text oyun
    //bekleniyor ise 3 nokta değil ise büyütüp küçültme)
    //default olarak false, text oyun bekleniyor ise true değil ise false değerini alır 
    //</param>
    private bool is3DotDone = false;
    //<param name="is3DotDone"> 
    //text üzerinde 3 nokta eklemesi yapılırken 3 adet nokta var mı yok mu kontrolünü sağlayan bool
    //default olarak false, 3 nokta eklenilene kadar false ve 3 nokta eklenmiş ise true değerini alır
    //</param>
    public int AnimVal = 0;
    //<param name="AnimVal">  
    //text yazısının büyüyüp küçülme animasyonu için hız değerini tutan değişken
    //default olarak 0dır yani animasyon yoktur ve sıfırdan büyük değerler alır
    //</param>
    //VARIABLES

    //MAIN FUNCTIONS
    private void Awake()//Script yüklendiği an çalışacak olan default fonksiyon
    {
        _Text = GetComponent<TMP_Text>();//Scriptin atandığı objeden text objesinin _Text değişkenine atanması
        if (_Text.text == "Oyun Bekleniyor")//_Text "oyun bekleniyor" ise
        { isLoadingAnim = true; StartCoroutine("Loading3DotAnim"); }//isLoadingAnim true yapılır ve Loading3DotAnim fonksiyonu coroutine olarak başlatılır
    }

    void Update()//her bir frame için çalışacak olan default fonksiyon
    {
        if (!isLoadingAnim)//tanımlanmış olan text değişkeni loading değil ise 
            TextGrowAnim();//Yazıyı büyültüp küçülten animasyonunun fonksiyon çağrımı  
    }
    //MAIN FUNCTIONS

    //COROUTINE FUNCTIONS
    IEnumerator Loading3DotAnim()//Bekleme yapılması için coroutine olarak tanımlanan Loading fonksiyonu
    {
    Start:
        yield return new WaitForSeconds(0.3f);//0.3 saniye beklenmesi sağlanılan komut
        if (_Text.text.Contains("Oyun Bekleniyor") && _Text.text != "Oyun Bekleniyor..." && !is3DotDone)//koşullar sağlanırsa text değişkeninin tuttuğu
            _Text.text += ".";//yazı parametresinin sonuna . eklemesi yapıyor
        else//değilse
        {
            if (_Text.text.Contains("Oyun Bekleniyor"))//koşulllar sağlanır ise
            {
                _Text.text = _Text.text.Remove(_Text.text.Length - 1);//text değişkeninin text parametresinin en son karakterini siler
                is3DotDone = true;//3 nokta olduğunu anlamamız için oluşturulan değişken true yapılır
                if (_Text.text == "Oyun Bekleniyor") is3DotDone = false;//bütün noktalar silinmiş ise 3 nokta kontrol değişkenini false yapar
            }
        }
        goto Start;//sürekli tekrar etmesi için başa döndürme komutu
    }
    //COROUTINE FUNCTIONS

    //FUNCTIONS
    private void TextGrowAnim()//Yazıyı büyültüp küçülten fonksiyon(her framede bir çalıştırdığımız için time.deltatime ile bu yüzden updatede çağrılması gerek)
    {
        if (_Text.fontSize >= 32 && isUpOrDown) { isUpOrDown = false; }//font boyutu 32den büyük ve büyütme değişkeni true ise false yapıyor ve küçültme işlemine geçiyor
        else if (_Text.fontSize <= 28 && !isUpOrDown) { isUpOrDown = true; }//değilse ve font boyutu 28den küçükse ve büyütme değişkeni false ise true yapıyor ve büyütme işlemine geçiyor

        if (isUpOrDown)//büyütme true ise
        {
            _Text.fontSize += AnimVal * Time.deltaTime;//font boyutuna ekleme yapılıyor
        }
        else
        {
            _Text.fontSize -= AnimVal * Time.deltaTime;//değil ise azaltma yapılıyor
        }
    }
    //FUNCTIONS 
}