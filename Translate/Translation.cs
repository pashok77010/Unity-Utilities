using System.Collections;
using System.Collections.Generic;

public static class Translation
{
    public static Dictionary<SupportedLanguages, Dictionary<string, string>> languageDictionary = new Dictionary<SupportedLanguages, Dictionary<string, string>>();

    public static void Initialize()
    {
        languageDictionary[SupportedLanguages.Russian] = new Dictionary<string, string>
        {
            // ДОБАВИТЬ

            {"Game", "Игра"},
            {"User", "Пользователь"},
            {"Load", "Загрузить"},
            {"Clear", "Очистить"},
            {"Done", "Выполнено"},

            // ДОБАВИТЬ

            // INFO
            {"Simulation", "Симуляция"},
            {"Rock", "Камень"},
            {"Paper", "Бумага"},
            {"Scissors", "Ножницы"},

            // GAME
            {"Highly rate the app!", "Высоко оцени приложение!"},
            {"Winner", "Победил"},
            {"Round", "Раунд"},
            {"Draw", "Ничья"},

            // MENU
            {"English", "Русский"},
            {"AREA SIZE", "Размер арены"},
            {"COUNT", "Количество"},
            {"SPEED", "Скорость"},
            {"Default", "По умолчанию"},
            {"Clear Info", "Очистить Инфо"},
            {"Info", "Инфо"},
            {"Turning", "Поворот"},
            {"Japanese mode", "Японский режим"},
        };

        languageDictionary[SupportedLanguages.Turkish] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "Simülasyon"},
            {"Rock", "Taş"},
            {"Paper", "Kağıt"},
            {"Scissors", "Makas"},

            // GAME
            {"Highly rate the app!", "Uygulamayı yüksek puanla!"},
            {"Winner", "Kazanan"},
            {"Round", "Tur"},
            {"Draw", "Beraberlik"},

            // MENU
            {"English", "Türkçe"},
            {"AREA SIZE", "Alan Boyutu"},
            {"COUNT", "Sayım"},
            {"SPEED", "Hız"},
            {"Default", "Varsayılan"},
            {"Clear Info", "Bilgiyi Temizle"},
            {"Info", "Bilgi"},
            {"Turning", "Dönüş"},
            {"Japanese mode", "Japon Modu"},
        };

        languageDictionary[SupportedLanguages.Spanish] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "Simulación"},
            {"Rock", "Piedra"},
            {"Paper", "Papel"},
            {"Scissors", "Tijeras"},

            // GAME
            {"Highly rate the app!", "¡Valora la app altamente!"},
            {"Winner", "Ganador"},
            {"Round", "Ronda"},
            {"Draw", "Empate"},

            // MENU
            {"English", "Español"},
            {"AREA SIZE", "Tamaño del área"},
            {"COUNT", "Cantidad"},
            {"SPEED", "Velocidad"},
            {"Default", "Por defecto"},
            {"Clear Info", "Borrar Info"},
            {"Info", "Info"},
            {"Turning", "Giro"},
            {"Japanese mode", "Modo japonés"},
        };

        languageDictionary[SupportedLanguages.French] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "Simulation"},
            {"Rock", "Pierre"},
            {"Paper", "Papier"},
            {"Scissors", "Ciseaux"},

            // GAME
            {"Highly rate the app!", "Évaluez l'application !"},
            {"Winner", "Gagnant"},
            {"Round", "Manche"},
            {"Draw", "Égalité"},

            // MENU
            {"English", "Français"},
            {"AREA SIZE", "TAILLE DE LA ZONE"},
            {"COUNT", "NOMBRE"},
            {"SPEED", "VITESSE"},
            {"Default", "Par défaut"},
            {"Clear Info", "Effacer les infos"},
            {"Info", "Infos"},
            {"Turning", "Tournant"},
            {"Japanese mode", "Mode japonais"},
        };

        languageDictionary[SupportedLanguages.German] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "Simulation"},
            {"Rock", "Stein"},
            {"Paper", "Papier"},
            {"Scissors", "Schere"},

            // GAME
            {"Highly rate the app!", "Bewerte die App hoch!"},
            {"Winner", "Gewinner"},
            {"Round", "Runde"},
            {"Draw", "Unentschieden"},

            // MENU
            {"English", "Deutsch"},
            {"AREA SIZE", "BEREICHSGRÖSSE"},
            {"COUNT", "ANZAHL"},
            {"SPEED", "GESCHWINDIGKEIT"},
            {"Default", "Standard"},
            {"Clear Info", "Info löschen"},
            {"Info", "Info"},
            {"Turning", "Drehung"},
            {"Japanese mode", "Japanischer Modus"},
        };

        languageDictionary[SupportedLanguages.Italian] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "Simulazione"},
            {"Rock", "Sasso"},
            {"Paper", "Carta"},
            {"Scissors", "Forbici"},

            // GAME
            {"Highly rate the app!", "Valuta l'app positivamente!"},
            {"Winner", "Vincitore"},
            {"Round", "Round"},
            {"Draw", "Pareggio"},

            // MENU
            {"English", "Italiano"},
            {"AREA SIZE", "Dimensione dell'area"},
            {"COUNT", "Conteggio"},
            {"SPEED", "Velocità"},
            {"Default", "Predefinito"},
            {"Clear Info", "Cancella Info"},
            {"Info", "Informazioni"},
            {"Turning", "Giro"},
            {"Japanese mode", "Modalità giapponese"},
        };

        languageDictionary[SupportedLanguages.Japanese] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "シミュレーション"},
            {"Rock", "岩"},
            {"Paper", "紙"},
            {"Scissors", "ハサミ"},

            // GAME
            {"Highly rate the app!", "アプリを高く評価してください！"},
            {"Winner", "勝者"},
            {"Round", "ラウンド"},
            {"Draw", "引き分け"},

            // MENU
            {"English", "日本語"},
            {"AREA SIZE", "エリアサイズ"},
            {"COUNT", "カウント"},
            {"SPEED", "スピード"},
            {"Default", "デフォルト"},
            {"Clear Info", "情報クリア"},
            {"Info", "情報"},
            {"Turning", "回転"},
            {"Japanese mode", "日本語モード"},
        };

        languageDictionary[SupportedLanguages.Korean] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "시뮬레이션"},
            {"Rock", "바위"},
            {"Paper", "종이"},
            {"Scissors", "가위"},

            // GAME
            {"Highly rate the app!", "앱을 높이 평가하세요!"},
            {"Winner", "승자"},
            {"Round", "라운드"},
            {"Draw", "무승부"},

            // MENU
            {"English", "한국어"},
            {"AREA SIZE", "영역 크기"},
            {"COUNT", "개수"},
            {"SPEED", "속도"},
            {"Default", "기본값"},
            {"Clear Info", "정보 지우기"},
            {"Info", "정보"},
            {"Turning", "회전"},
            {"Japanese mode", "일본어 모드"},
        };

        languageDictionary[SupportedLanguages.ChineseSimplified] = new Dictionary<string, string>
        {
            // INFO
            {"Simulation", "模拟"},
            {"Rock", "石头"},
            {"Paper", "纸"},
            {"Scissors", "剪刀"},

            // GAME
            {"Highly rate the app!", "请给应用高评分！"},
            {"Winner", "胜利者"},
            {"Round", "回合"},
            {"Draw", "平局"},

            // MENU
            {"English", "英语"},
            {"AREA SIZE", "区域大小"},
            {"COUNT", "数量"},
            {"SPEED", "速度"},
            {"Default", "默认"},
            {"Clear Info", "清除信息"},
            {"Info", "信息"},
            {"Turning", "转向"},
            {"Japanese mode", "日语模式"},
        };
    }
}
