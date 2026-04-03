import React from "react";
import { useLanguage } from "./LanguageContext";

function LanguageSwitcher() {
  const { language, changeLanguage } = useLanguage();

  return (
    <div className="language-switcher">
      <button
        className={language === "en" ? "lang-btn active" : "lang-btn"}
        onClick={() => changeLanguage("en")}
      >
        English
      </button>

      <button
        className={language === "hi" ? "lang-btn active" : "lang-btn"}
        onClick={() => changeLanguage("hi")}
      >
        हिन्दी
      </button>

      <button
        className={language === "es" ? "lang-btn active" : "lang-btn"}
        onClick={() => changeLanguage("es")}
      >
        Español
      </button>
    </div>
  );
}

export default LanguageSwitcher;