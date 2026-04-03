import React, { createContext, useContext, useState } from "react";

const LanguageContext = createContext();

const translations = {
  en: {
    pageTitle: "Global Connect",
    subtitle: "Professional Localization Demo using React Context API",
    heroTitle: "Welcome to Our Platform",
    heroText:
      "This page demonstrates how Context API can be used to manage language settings across a React application in a clean and scalable way.",
    feature1Title: "Easy Language Switching",
    feature1Text:
      "Users can instantly switch the interface language without refreshing the page.",
    feature2Title: "Centralized Content Management",
    feature2Text:
      "All translated content is stored in one place, making maintenance simple and efficient.",
    feature3Title: "Better User Experience",
    feature3Text:
      "Localization helps users feel more comfortable by allowing them to interact in their preferred language.",
    footerText: "React Context API Localization Example"
  },

  hi: {
    pageTitle: "ग्लोबल कनेक्ट",
    subtitle: "React Context API का उपयोग करके प्रोफेशनल लोकलाइजेशन डेमो",
    heroTitle: "हमारे प्लेटफ़ॉर्म पर आपका स्वागत है",
    heroText:
      "यह पेज दिखाता है कि React एप्लिकेशन में Context API का उपयोग भाषा सेटिंग्स को आसान और व्यवस्थित तरीके से संभालने के लिए कैसे किया जा सकता है।",
    feature1Title: "आसान भाषा परिवर्तन",
    feature1Text:
      "यूज़र बिना पेज रिफ्रेश किए तुरंत भाषा बदल सकते हैं।",
    feature2Title: "केंद्रीकृत कंटेंट प्रबंधन",
    feature2Text:
      "सारा अनुवादित कंटेंट एक ही जगह रखा जाता है, जिससे रखरखाव आसान हो जाता है।",
    feature3Title: "बेहतर उपयोगकर्ता अनुभव",
    feature3Text:
      "लोकलाइजेशन यूज़र्स को उनकी पसंदीदा भाषा में काम करने की सुविधा देता है।",
    footerText: "React Context API लोकलाइजेशन उदाहरण"
  },

  es: {
    pageTitle: "Conexión Global",
    subtitle: "Demostración profesional de localización usando React Context API",
    heroTitle: "Bienvenido a Nuestra Plataforma",
    heroText:
      "Esta página demuestra cómo se puede usar Context API para administrar la configuración de idioma en una aplicación React de forma limpia y escalable.",
    feature1Title: "Cambio Fácil de Idioma",
    feature1Text:
      "Los usuarios pueden cambiar el idioma de la interfaz al instante sin recargar la página.",
    feature2Title: "Gestión Centralizada del Contenido",
    feature2Text:
      "Todo el contenido traducido se almacena en un solo lugar, lo que facilita el mantenimiento.",
    feature3Title: "Mejor Experiencia de Usuario",
    feature3Text:
      "La localización ayuda a los usuarios a sentirse más cómodos al interactuar en su idioma preferido.",
    footerText: "Ejemplo de localización con React Context API"
  }
};

export const LanguageProvider = ({ children }) => {
  const [language, setLanguage] = useState("en");

  const changeLanguage = (lang) => {
    setLanguage(lang);
  };

  return (
    <LanguageContext.Provider
      value={{
        language,
        changeLanguage,
        text: translations[language]
      }}
    >
      {children}
    </LanguageContext.Provider>
  );
};

export const useLanguage = () => useContext(LanguageContext);