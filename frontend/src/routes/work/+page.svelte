<script>
	import { ArrowUpRight } from 'lucide-svelte';

	const technicalGrowth = [
		{
			title: 'Frontend Focused',
			period: '2020-2023',
			skills: 'HTML • CSS • JavaScript • Vue'
		},
		{
			title: 'Full Stack Growth',
			period: '2023-2024',
			skills: 'Angular • Backend • Databases • APIs'
		},
		{
			title: 'Architecture & DevOps',
			period: '2024-Present',
			skills: 'Cloud • CI/CD • System Design'
		}
	];

	const jobs = [
		{
			company: 'Universal Robots',
			role: 'Software Engineer',
			period: 'August 2024 - Present',
			url: 'https://www.universal-robots.com',
			description: 'Working on next-generation robotics software interfaces.',
			achievements: [
				'Contributed to core software architecture',
				'Improved development workflows',
				'Implemented new user interface features'
			]
		},
		{
			company: 'Vemco Group',
			role: 'Frontend Developer',
			period: 'January 2022 - August 2024',
			url: 'https://www.vemcogroup.com',
			description: 'Led frontend development for people counting and retail analytics solutions.',
			achievements: [
				'Modernized legacy codebase',
				'Improved application performance',
				'Implemented real-time data visualization'
			]
		},
		{
			company: 'LAIT',
			role: 'Frontend Developer',
			period: 'August 2020 - January 2022',
			url: 'https://www.lait.dk',
			description: 'Developed modern web applications for various business solutions.',
			achievements: [
				'Built responsive user interfaces',
				'Collaborated with cross-functional teams',
				'Delivered client-specific solutions'
			]
		}
	];
</script>

<section class="grid grid-cols-1 gap-8 py-12 lg:grid-cols-10 lg:gap-24">
	<div class="col-span-1 lg:col-span-7">
		<h1
			class="mb-8 font-mono text-2xl font-bold tracking-tight text-neutral-900 dark:text-white lg:mb-16 lg:text-3xl"
		>
			Experience
		</h1>

		<div class="space-y-12 lg:space-y-16">
			{#each jobs as job}
				<div
					class="group relative border-l-2 border-neutral-200 pl-6 dark:border-neutral-800 lg:pl-8"
				>
					<div
						class="absolute -left-1.5 top-0 h-2.5 w-2.5 rounded-full bg-neutral-100 dark:bg-neutral-600 lg:h-3 lg:w-3"
					></div>

					<a
						href={job.url}
						target="_blank"
						rel="noopener noreferrer"
						class="mb-2 flex items-center gap-2 font-mono text-xl font-bold tracking-tight text-neutral-800 transition-all dark:text-neutral-100 lg:text-2xl"
					>
						{job.company}
						<ArrowUpRight
							class="h-4 w-4 opacity-0 transition-opacity group-hover:opacity-100 lg:h-5 lg:w-5"
						/>
					</a>

					<div
						class="mb-3 font-mono text-xs uppercase tracking-widest text-neutral-500 dark:text-neutral-400 lg:mb-4 lg:text-sm"
					>
						<span class="font-medium">{job.role}</span>
						<span class="mx-2">·</span>
						<span class="text-neutral-400 dark:text-neutral-500">{job.period}</span>
					</div>

					{#if job.description}
						<p
							class="mb-3 text-sm font-light leading-relaxed text-neutral-700 dark:text-neutral-300 lg:mb-4 lg:text-base"
						>
							{job.description}
						</p>
					{/if}

					{#if job.achievements && job.achievements.length > 0}
						<ul
							class="space-y-2 text-xs font-light text-neutral-600 dark:text-neutral-400 lg:text-sm"
						>
							{#each job.achievements as achievement}
								<li class="flex items-center gap-2 transition-all">
									<div class="h-1 w-1 rounded-full bg-blue-400"></div>
									{achievement}
								</li>
							{/each}
						</ul>
					{/if}
				</div>
			{/each}
		</div>
	</div>

	<!-- Technical Growth section for mobile -->
	<div class="mt-16 lg:hidden">
		<h2 class="mb-8 font-mono text-xl font-bold text-neutral-900 dark:text-white">
			Technical Growth
		</h2>
		<div class="space-y-8">
			{#each technicalGrowth as phase}
				<div class="border-l-2 border-neutral-800 pl-4">
					<h3 class="font-mono text-sm tracking-wide text-neutral-500">{phase.period}</h3>
					<p class="mt-1 text-lg font-medium">{phase.title}</p>
					<p class="mt-1 text-sm text-neutral-400">{phase.skills}</p>
				</div>
			{/each}
		</div>
	</div>

	<!-- Technical Growth section for desktop -->
	<div class="col-span-3 hidden pt-20 lg:flex lg:justify-end">
		<div class="space-y-12">
			{#each technicalGrowth as phase}
				<div class="border-l-2 border-neutral-800 pl-4">
					<h3 class="font-mono text-sm tracking-wide text-neutral-500">{phase.period}</h3>
					<p class="mt-1 text-lg font-medium">{phase.title}</p>
					<p class="mt-1 text-sm text-neutral-400">{phase.skills}</p>
				</div>
			{/each}
		</div>
	</div>
</section>
