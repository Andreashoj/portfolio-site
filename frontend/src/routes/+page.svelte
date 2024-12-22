<script lang="ts">
	import InteractiveTerminal from '$components/features/InteractiveTerminal.svelte';
	import { isDesktop } from '$lib/stores/mediaQuery';
	import {
		siTypescript,
		siSvelte,
		siReact,
		siDocker,
		siVuedotjs,
		siAngular,
		siKubernetes,
		siNginx,
		siDotnet,
		siNodedotjs,
		siSharp
	} from 'simple-icons';
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

<div>
	<h2 class="mt-12 text-xl font-bold underline">Tech stack:</h2>
	<ul class="mt-4 list-disc pl-6">
		<li>
			<div class="flex items-center">
				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siTypescript.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Typescript</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siSvelte.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Svelte</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siVuedotjs.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Vue</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siAngular.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Angular</span>
			</div>
		</li>

		<li class="mt-2">
			<div class="flex items-center">
				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siDotnet.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">.NET</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siNodedotjs.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Node.js</span>
			</div>
		</li>

		<li class="mt-2">
			<div class="flex items-center">
				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siDocker.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Docker</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siNginx.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Nginx</span>

				<span class="mx-2">+</span>

				<svg class="mr-1.5 h-4 w-4" role="img" viewBox="0 0 24 24">
					<path d={siKubernetes.path} class="fill-gray-900 dark:fill-white" />
				</svg>
				<span class="underline">Kubernetes</span>
			</div>
		</li>
	</ul>
</div>
