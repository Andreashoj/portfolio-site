<script lang="ts">
	import { page } from '$app/stores';
	import { Github, LinkedinIcon } from 'lucide-svelte';
</script>

<nav
	class="fixed top-0 z-50 flex h-16 w-full justify-center border-b border-gray-200 bg-gray-100 px-5 dark:border-gray-700 dark:bg-gray-900 xl:px-0"
>
	<div class="grid max-w-7xl grid-cols-10 items-center">
		<div class="flex gap-4 dark:text-gray-300">
			<a href="/" class:active={$page.url.pathname === '/'}>home</a>
			<a href="/blog" class:active={$page.url.pathname === '/blog'}>blog</a>
			<a href="/work" class:active={$page.url.pathname === '/work'}>work</a>
		</div>

		<div class="col-start-10 flex justify-end gap-3">
			<a
				href="https://github.com/Andreashoj"
				class="duration group flex items-center justify-center rounded-full border border-transparent bg-gray-200 p-1 transition duration-500 hover:border-gray-900 hover:bg-transparent dark:hover:border-white"
				target="_blank"
			>
				<Github
					class="h-4 w-4 fill-gray-900 text-gray-900 transition duration-500 group-hover:text-transparent dark:group-hover:fill-white"
				/>
			</a>
			<a
				href="https://www.linkedin.com/in/andreas-h%C3%B8j-a9838514b/"
				class="duration group flex items-center justify-center rounded-full border border-transparent bg-gray-200 p-1 transition duration-500 hover:border-gray-900 hover:bg-transparent dark:hover:border-white"
				target="_blank"
			>
				<LinkedinIcon
					class="h-4 w-4 fill-gray-900 text-transparent transition duration-500 dark:group-hover:fill-white"
				/>
			</a>
		</div>
	</div>
</nav>

<style>
	.active {
		@apply border-b-2 border-blue-900 dark:border-blue-200;
	}
</style>
