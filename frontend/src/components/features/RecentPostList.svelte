<script lang="ts">
	import RecentPostListItem from '$components/features/RecentPostListItem.svelte';
	export let posts: SanityPost[];
</script>

<h2 class="mt-12 text-xl font-bold underline">Recent posts:</h2>
<div class="mt-5 flex flex-col">
	{#each posts as post}
		<RecentPostListItem {post} />
	{/each}
</div>
