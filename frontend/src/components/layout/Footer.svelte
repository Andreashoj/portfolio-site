<script lang="ts">
	import GithubRepoDetails from '$components/features/GithubRepoDetails.svelte';
	import ThemeToggle from '$components/features/ThemeToggle.svelte';
</script>

<footer
	class="flex justify-center border-t border-gray-200 bg-gray-100 px-5 py-12 dark:border-gray-700 dark:bg-gray-900 xl:px-0"
>
	<div class="grid max-w-7xl grid-cols-10">
		<div class="col-span-4">
			<a
				class="mb-4 block text-sm text-gray-500 underline dark:text-gray-400"
				href="https://github.com/Andreashoj/portfolio-site"
				target="_blank"
			>
				view source
			</a>
			<GithubRepoDetails />
		</div>
		<ThemeToggle />
	</div>
</footer>

<style>
	:global(.dark) {
		color-scheme: dark;
	}
</style>
