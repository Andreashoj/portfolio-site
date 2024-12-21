<script lang="ts">
	import InteractiveTerminal from '$components/features/InteractiveTerminal.svelte';
	import { isDesktop } from '$lib/stores/mediaQuery';
</script>

<div class="relative mt-8 flex w-full justify-between">
	<div class="w-full">
		<h1 class="text-6xl font-light">Hi, I'm <span class="block font-black">Andreas</span></h1>
		<h3 class="mt-3 bg-gray-800 p-1.5 indent-1.5 text-2xl text-slate-50 dark:bg-blue-500">
			Fullstack Developer
		</h3>
	</div>

	{#if $isDesktop}
		<div class="absolute right-5 w-[600px]">
			<InteractiveTerminal />
		</div>
	{/if}
</div>
