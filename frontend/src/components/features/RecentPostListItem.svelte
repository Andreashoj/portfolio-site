<script lang="ts">
	import { Eye, LucideArrowUp } from 'lucide-svelte';

	export let post: SanityPost;
</script>

<div
	class="group relative mb-4 w-full rounded border border-slate-800 p-4 transition hover:border-slate-600"
>
	<a
		href="/blog/{post.slug.current}"
		class="absolute left-0 top-0 h-full w-full"
		aria-label="link to blogpost {post.title}"
	></a>
	<span class="text-sm text-slate-600">{post.publishedAt}</span>
	<h2 class="mt-1 text-xl font-semibold capitalize">{post.title}</h2>
	<span>
		{#if post.pageView != null}
			{post.pageView ?? 0} views
		{:else}
			<div class="inline-flex items-center gap-2 text-gray-500">
				<span
					class="animate-pulse bg-gradient-to-r from-gray-200 to-gray-300 bg-clip-text text-transparent"
				>
					Loading views
				</span>
			</div>
		{/if}
	</span>

	<LucideArrowUp
		class="absolute right-4 top-4 h-4 w-4 rotate-45 transition group-hover:rotate-90 dark:text-slate-500"
	/>
</div>
