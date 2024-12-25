<script lang="ts">
	import RecentPostListItem from '$components/features/RecentPostListItem.svelte';
	import { onMount } from 'svelte';
	export let posts: SanityPost[];

	async function loadPostViews() {
		const slugs = posts.map((p) => p.slug.current);
		const response = await fetch('/api/pageview/batch', {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(slugs)
		});

		const data: PageView[] = await response.json();

		posts = posts.map((post) => {
			const blogPageView = data.find((p) => p.slug == post.slug.current);
			return {
				...post,
				pageView: blogPageView!.pageView
			};
		});
	}

	onMount(loadPostViews);
</script>

<h2 class="mt-12 text-xl font-bold underline">Recent posts:</h2>
<div class="mt-5 flex flex-col">
	{#each posts as post}
		<RecentPostListItem {post} />
	{/each}
</div>
