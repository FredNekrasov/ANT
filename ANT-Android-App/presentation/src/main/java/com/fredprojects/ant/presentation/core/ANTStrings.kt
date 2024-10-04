package com.fredprojects.ant.presentation.core

import androidx.compose.runtime.mutableStateListOf

/**
 * This class contains all the constants and strings used in the application.
 * Defines the error messages and screen routes.
 */
object ANTStrings {
    const val MAIN_TITLE = "Храм Александра Невского"
    const val MENU = "Меню"
    // error messages
    const val CONNECTION_ERROR = "Ошибка соединения с сервером"
    const val NO_INTERNET = "Нет интернета"
    const val NO_DATA = "Нет данных"
    const val SERIALIZATION_ERROR = "Сервер отправил некорректные данные"
    const val UNKNOWN = "Неизвестная ошибка"
    // screen routes
    const val MAIN = "Главная страница"
    const val PARISH_LIFE = "Приходская жизнь"
    const val SCHEDULE = "Расписание Богослужений"
    const val SPIRITUAL_TALKS = "Духовные беседы"
    const val YOUTH_CLUB = "Молодежный клуб"
    const val PRIESTHOOD = "Священство"
    const val ADVICES = "Советы священника"
    const val HISTORY = "История"
    const val SACRAMENTS = "Требы"
    const val CONTACTS = "Контакты"
    const val INFORMATION = "Информация"
    const val VOLUNTEERISM = "Приходская добровольческая служба"
    // URLs
    const val SPIRITUAL_TALKS_URL = "https://hramalnevskogo.ru/page40967215.html"
    const val INFORMATION_URL = "https://hramalnevskogo.ru/page42533272.html"
    // other
    const val PHONE = "Телефон"
    const val EMAIL = "Электронная почта"
    const val TELEGRAM = "Телеграм"
    const val VK = "VK"

    val screens = mutableStateListOf(MAIN, PARISH_LIFE, SCHEDULE, SPIRITUAL_TALKS, YOUTH_CLUB, PRIESTHOOD, ADVICES, HISTORY, SACRAMENTS, CONTACTS, INFORMATION, VOLUNTEERISM)
}