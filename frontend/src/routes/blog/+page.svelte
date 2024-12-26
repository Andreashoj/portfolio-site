<script lang="ts">
	import { LucideArrowUp } from 'lucide-svelte';
	export let data;
</script>

<h2 class="mt-12 text-3xl font-semibold capitalize">Blogs</h2>
<div class="my-4 grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
	{#each data.posts as post}
		<a href="blog/{post.slug.current}" class="group relative">
			<div class="flex h-64 flex-col rounded-lg border border-slate-800 dark:bg-gray-900">
				<div class="flex flex-1 flex-col p-6">
					<!-- Date -->
					<p class="mb-2 text-sm text-gray-500 dark:text-gray-400">
						{post.publishedAt}
					</p>

					<!-- Title -->
					<h2
						class="mb-3 text-2xl font-bold text-gray-900 transition dark:text-white dark:group-hover:text-gray-400"
					>
						{post.title}
					</h2>

					<!-- Description -->
					<p class="line-clamp-3 text-gray-600 dark:text-gray-300">
						{post.description}
					</p>

					<div class="mt-auto">
						<!-- Categories/Tags -->
						{#if post.categories && post.categories.length > 0}
							<div class="mt-3 flex flex-wrap gap-2">
								{#each post.categories as category}
									<span class="rounded-full bg-slate-800 px-3 py-1 text-xs text-slate-200">
										{category.title}
									</span>
								{/each}
							</div>
						{/if}
					</div>
				</div>
			</div>

			<LucideArrowUp
				class="absolute right-4 top-4 h-4 w-4 rotate-45 transition group-hover:rotate-90 dark:text-slate-500"
			/>
		</a>
	{/each}
</div>
