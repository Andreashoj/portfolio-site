import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';

export default defineConfig({
	plugins: [sveltekit()],
	server: {
		proxy: {
			'/api': {
				target: 'http://localhost:5000',
				rewrite: (path) => path.replace(/^\/api/, '')
			}
		}
	},
	define: {
		'import.meta.env.VITE_PUBLIC_API_KEY': JSON.stringify(process.env.VITE_PUBLIC_API_KEY)
	}
});
