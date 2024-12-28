<script lang="ts">
	import BlogComponent from '$components/features/BlogComponent.svelte';
	import { onMount } from 'svelte';
	import { api } from '$lib/api';
	import { ChevronRight, Eye } from 'lucide-svelte';

	export let data: PageData;

	async function incrementPostCount() {
		const response = await api.post('/pageview/increment', data.post.slug.current);
		const result: PageView = await response.json();
		data.post.pageView = result.pageView;
	}

	onMount(incrementPostCount);
</script>

<div class="mt-4 flex items-center capitalize">
	<a href="/blog" class="text-gray-400 transition hover:text-white">Blogs</a>
	<ChevronRight class="mx-2 h-4 w-4" />
	<span>{data.post.title}</span>
</div>

<article class="w-full">
	<div class="mt-12 flex w-full items-end justify-between">
		<div>
			<h1 class="text-4xl">{data.post.title}</h1>
			<p class="mt-4">{data.post.publishedAt}</p>
		</div>
		<span class="flex">
			{data.post.pageView ?? 'loading'}
			<Eye class="ml-2 text-gray-300" />
		</span>
	</div>

	<div class="mb-8 mt-4">
		<!-- Categories/Tags -->
		{#if data.post.categories && data.post.categories.length > 0}
			<div class="mt-3 flex flex-wrap gap-2">
				{#each data.post.categories as category}
					<span class="rounded-full bg-slate-800 px-3 py-1 text-xs text-slate-200">
						{category.title}
					</span>
				{/each}
			</div>
		{/if}
	</div>

	<BlogComponent content={data.post.body} />
</article>
