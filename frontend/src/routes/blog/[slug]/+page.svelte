<script lang="ts">
	import BlogComponent from '$components/features/BlogComponent.svelte';
	import { onMount } from 'svelte';

	export let data: PageData;

	async function incrementPostCount() {
		console.log(data);
		const response = await fetch('/api/pageview/increment', {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(data.post.slug.current)
		});

		const result: PageView = await response.json();
		data.post.pageView = result.pageView;
	}

	onMount(incrementPostCount);
</script>

<article>
	page views {data.post.pageView ?? 'loading'}
	<h1>{data.post.title}</h1>
	<p>By {data.post.author}</p>
	<BlogComponent content={data.post.body} />
</article>
