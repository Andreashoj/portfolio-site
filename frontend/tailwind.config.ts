import typography from '@tailwindcss/typography';
import type { Config } from 'tailwindcss';

export default {
	content: ['./src/**/*.{html,js,svelte,ts}'],

	theme: {
		extend: {
			fontFamily: {
				sans: ['DM Sans', 'sans-serif'], // Replace 'YourFontName' with your font's name
			},
		},
	},

	plugins: [typography]
} satisfies Config;
