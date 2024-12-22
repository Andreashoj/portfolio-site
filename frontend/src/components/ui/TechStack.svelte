<script>
	import {
		siAngular,
		siDocker,
		siDotnet,
		siKubernetes,
		siNginx,
		siNodedotjs,
		siSvelte,
		siTypescript,
		siVuedotjs
	} from 'simple-icons';
</script>

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
