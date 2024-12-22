<script lang="ts">
	import { LucideArrowUp } from 'lucide-svelte';

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
	<p class="mt-2 text-sm">4002 views</p>

	<LucideArrowUp
		class="absolute right-4 top-4 h-4 w-4 rotate-45 transition group-hover:rotate-90 dark:text-slate-500"
	/>
</div>
