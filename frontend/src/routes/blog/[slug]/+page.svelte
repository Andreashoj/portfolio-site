<script lang="ts">
	import BlogComponent from '$components/features/BlogComponent.svelte';
	import { onMount } from 'svelte';
	import { api } from '$lib/api';
	import { ChevronRight, Eye, Heart } from 'lucide-svelte';

	export let data: PageData;
	let hasLiked = false;

	async function incrementPostCount() {
		const response = await api.post('/pageview/increment', data.post.slug.current);
		const result: Blog = await response.json();
		data.post.pageView = result.pageView;
	}

	async function incrementLikeCount() {
		if (hasLiked) return;

		const response = await api.patch(`/blogs/${data.post.slug.current}/likes`);
		const result: Blog = await response.json();
		data.post.likes = result.likes;

		// Store in localStorage
		const likedPosts = JSON.parse(localStorage.getItem('likedPosts') || '[]');
		likedPosts.push(data.post.slug.current);
		localStorage.setItem('likedPosts', JSON.stringify(likedPosts));
		hasLiked = true;
	}

	async function getLikeCount() {
		const response = await api.get(`/blogs/${data.post.slug.current}/likes`);
		const result: Blog = await response.json();
		data.post.likes = result.likes;
	}

	onMount(() => {
		incrementPostCount();
		getLikeCount();

		const likedPosts = JSON.parse(localStorage.getItem('likedPosts') || '[]');
		hasLiked = likedPosts.includes(data.post.slug.current);
	});
</script>

<article class="w-full rounded bg-gray-200 px-6 pt-2 dark:bg-[#102030]">
	<div class="mt-1 flex items-center capitalize">
		<a href="/blog" class="text-gray-400 transition hover:text-white">Blogs</a>
		<ChevronRight class="mx-2 h-4 w-4" />
		<span>{data.post.title}</span>
	</div>

	<div class="mt-8 flex w-full items-end justify-between">
		<div>
			<h1 class="text-4xl font-black">{data.post.title}</h1>
			<p class="mt-4">{data.post.publishedAt}</p>
		</div>

		<div class="flex items-center">
			<span class="mr-5 flex">
				{data.post.pageView ?? 'loading'}
				<Eye class="ml-2 text-gray-600 dark:text-gray-300" />
			</span>

			<span class="mr-2.5">{data.post.likes}</span>
			<button on:click={incrementLikeCount} class="hover:opacity-75">
				<Heart
					fill={hasLiked ? '#ec4899' : 'none'}
					color={hasLiked ? '#ec4899' : '#374151'}
					size={20}
				/>
			</button>
		</div>
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

	<span class="block h-px w-full bg-gray-500"></span>

	<h2 class="pb-4 pt-10 text-xl font-semibold text-gray-800 dark:text-gray-200">
		Thanks for reading!
	</h2>
	<div class="ml-1 flex items-center pb-12">
		<span class="mr-5 flex">
			{data.post.pageView ?? 'loading'}
			<Eye class="ml-2 text-gray-600 dark:text-gray-300" />
		</span>

		<span class="mr-2.5">{data.post.likes}</span>
		<button
			on:click={incrementLikeCount}
			class="hover:opacity-75 {hasLiked ? 'pointer-events-none' : ''}"
		>
			<Heart
				fill={hasLiked ? '#ec4899' : 'none'}
				color={hasLiked ? '#ec4899' : '#374151'}
				size={20}
			/>
		</button>
	</div>

	<h3 class="pb-4 text-xl text-gray-800 dark:text-gray-200">Comments</h3>
</article>
