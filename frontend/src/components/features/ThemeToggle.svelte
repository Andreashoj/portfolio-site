<script lang="ts">
	import { Sun, Moon, Monitor } from 'lucide-svelte';

	type Theme = 'light' | 'dark' | 'auto';
	let currentTheme: Theme = 'auto';
	let systemDarkMode = false;

	if (typeof window !== 'undefined') {
		const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
		systemDarkMode = mediaQuery.matches;

		mediaQuery.addEventListener('change', (e) => {
			systemDarkMode = e.matches;
		});
	}

	$: isDarkMode = currentTheme === 'dark' || (currentTheme === 'auto' && systemDarkMode);

	$: {
		if (typeof document !== 'undefined') {
			if (isDarkMode) {
				document.documentElement.classList.add('dark');
			} else {
				document.documentElement.classList.remove('dark');
			}
		}
	}
</script>

<div class="col-span-2 col-start-9 flex h-10 w-full items-center justify-end gap-1">
	<div class="flex rounded-full bg-gray-200 p-1 dark:bg-gray-800">
		<button
			class="rounded-full p-2 transition-all {currentTheme === 'light'
				? 'bg-white text-black shadow-sm'
				: 'text-gray-600 hover:bg-gray-300/50 dark:text-gray-400 dark:hover:bg-gray-700/50'}"
			on:click={() => (currentTheme = 'light')}
		>
			<Sun class="h-4 w-4" />
		</button>

		<button
			class="rounded-full p-2 transition-all {currentTheme === 'dark'
				? 'bg-white text-black shadow-sm dark:bg-gray-700 dark:text-white'
				: 'text-gray-600 hover:bg-gray-300/50 dark:text-gray-400 dark:hover:bg-gray-700/50'}"
			on:click={() => (currentTheme = 'dark')}
		>
			<Moon class="h-4 w-4" />
		</button>

		<button
			class="rounded-full p-2 transition-all {currentTheme === 'auto'
				? 'bg-white text-black shadow-sm dark:bg-gray-700 dark:text-white'
				: 'text-gray-600 hover:bg-gray-300/50 dark:text-gray-400 dark:hover:bg-gray-700/50'}"
			on:click={() => (currentTheme = 'auto')}
		>
			<Monitor class="h-4 w-4" />
		</button>
	</div>
</div>
