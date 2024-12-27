<script lang="ts">
	import BlogComponent from '$components/features/BlogComponent.svelte';
	import { onMount } from 'svelte';
	import { api } from '$lib/api';

	export let data: PageData;

	async function incrementPostCount() {
		const response = await api.post('/pageview/increment', data.post.slug.current);
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
