import React from "react";
import "./App.css";
import { LanguageProvider, useLanguage } from "./LanguageContext";
import LanguageSwitcher from "./LanguageSwitcher";

function PageContent() {
  const { text } = useLanguage();

  return (
    <div className="app-container">
      <header className="topbar">
        <div>
          <h1 className="brand">{text.pageTitle}</h1>
          <p className="subtitle">{text.subtitle}</p>
        </div>
        <LanguageSwitcher />
      </header>

      <main className="main-content">
        <section className="hero-card">
          <h2>{text.heroTitle}</h2>
          <p>{text.heroText}</p>
        </section>

        <section className="features-section">
          <div className="feature-card">
            <h3>{text.feature1Title}</h3>
            <p>{text.feature1Text}</p>
          </div>

          <div className="feature-card">
            <h3>{text.feature2Title}</h3>
            <p>{text.feature2Text}</p>
          </div>

          <div className="feature-card">
            <h3>{text.feature3Title}</h3>
            <p>{text.feature3Text}</p>
          </div>
        </section>
      </main>

      <footer className="footer">
        <p>{text.footerText}</p>
      </footer>
    </div>
  );
}

function App() {
  return (
    <LanguageProvider>
      <PageContent />
    </LanguageProvider>
  );
}

export default App;