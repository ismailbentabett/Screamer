/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}", "./projects/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        "dodger-blue": {
          DEFAULT: "#1DA1F2",
          50: "#F1F9FE",
          100: "#DEF1FD",
          200: "#B7E1FB",
          300: "#91D1F9",
          400: "#6AC1F6",
          500: "#44B1F4",
          600: "#1DA1F2",
          700: "#0C82CB",
          800: "#096096",
          900: "#063E61",
          950: "#042D47",
        },
      },
    },
  },
  plugins: [
    require("@tailwindcss/typography"),
    require("@tailwindcss/forms"),
    require("@tailwindcss/aspect-ratio"),
    require("@tailwindcss/line-clamp"),
  ],
};
